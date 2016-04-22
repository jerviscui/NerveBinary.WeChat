using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using Core.Domain;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Web.Areas.Admin.Models;
using Web.Areas.Admin.Models.Home;
using Web.Infrastructure;
using WebMatrix.WebData;
using WebService;

namespace Web.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        private readonly ISubjectInfoService _subjectinfoInfoService;
        private readonly ISubjectOptionService _subjectOptionService;
        private readonly ISubjectResultService _subjectResultService;
        private readonly IPictureService _pictureService;

        public HomeController(ISubjectInfoService subjectinfoInfoService, ISubjectOptionService subjectOptionService, ISubjectResultService subjectResultService, IPictureService pictureService)
        {
            _subjectinfoInfoService = subjectinfoInfoService;
            _subjectOptionService = subjectOptionService;
            _subjectResultService = subjectResultService;
            _pictureService = pictureService;
        }

        #region Private
        private const string Path = "/Upload/Game/";
        private static readonly string[] AllowType = new[] { "image/gif", "image/jpeg", "image/png" };

        private bool IsImage(string contentType)
        {
            return AllowType.Contains(contentType.ToLower());
        }
        #endregion


        [AllowAnonymous]
        // GET: Admin/Home
        public ActionResult Index(int pageIndex = 0, int pageSize = 10)
        {
            var data = new PageModel<SubjectInfoModel>();
            var list = _subjectinfoInfoService.GetList(pageIndex, pageSize);

            if (list != null)
            {
                data = list.ToModel<SubjectInfo, SubjectInfoModel>();
                data.Data.AddRange(list.Select(o => o.ToAdminModel()));
            }

            return View(data);
        }

        [HttpPost]
        public ActionResult GridGet([DataSourceRequest]DataSourceRequest request)
        {
            var data = new DataSourceResult();
            var list = _subjectinfoInfoService.GetList(request.Page - 1, request.PageSize);

            if (list != null)
            {
                //data = list.ToModel<SubjectInfo, SubjectInfoModel>();
                request.Page = 1;
                data = list.Select(o => o.ToAdminModel()).ToDataSourceResult(request);
                data.Total = list.Total;
            }

            return new JsonResult() { Data = data };
        }

        public ActionResult Results(int subjectId, int pageIndex = 0, int pageSize = 10)
        {
            var data = new PageModel<SubjectResultModel>();
            var list = _subjectResultService.GetResults(subjectId, pageIndex, pageSize);
            ViewBag.SubjectId = subjectId;

            if (list != null)
            {
                data = list.ToModel<SubjectResult, SubjectResultModel>();
                data.Data.AddRange(list.Select(o => o.ToAdminModel()));
            }

            return View(data);
        }

        [HttpPost]
        public ActionResult GetResults([DataSourceRequest]DataSourceRequest request, int subjectId)
        {
            var data = new DataSourceResult();
            var list = _subjectResultService.GetResults(subjectId, request.Page - 1, request.PageSize);

            if (list != null)
            {
                //data = list.ToModel<SubjectInfo, SubjectInfoModel>();
                request.Page = 1;
                data = list.Select(o => o.ToAdminModel()).ToDataSourceResult(request);
                data.Total = list.Total;
            }

            return Json(data);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult GetOptions([DataSourceRequest]DataSourceRequest request, int subjectId)
        {
            //var data = new PageModel<SubjectOptionModel>();
            var data = new DataSourceResult();
            var list = _subjectOptionService.GetOptions(subjectId, request.Page - 1, request.PageSize);

            if (list != null)
            {
                //data = list.ToModel<SubjectOption, SubjectOptionModel>();
                request.Page = 1;
                data = list.Select(o => o.ToAdminModel()).ToDataSourceResult(request);
                data.Total = list.Total;
            }

            return Json(data);
        }

        [HttpPost]
        public ActionResult Hide([DataSourceRequest]DataSourceRequest request, SubjectInfoModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                _subjectinfoInfoService.Hide(model.Id);
            }

            return GridGet(request);
        }

        public ActionResult NewGame()
        {
            ViewBag.Create = true;
            var model = new SubjectInfoModel();

            return View("EditGame", model);
        }

        [HttpPost]
        public ActionResult NewGame(SubjectInfoModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var file1 = Request.Files["Picture"];
                var file2 = Request.Files["ResultPicture"];
                if (file1 == null || !IsImage(file1.ContentType) || file2 == null || !IsImage(file2.ContentType))
                {
                    ModelState.AddModelError("", "please choose a picture");
                }
                else
                {
                    var subject = model.ToEntity();
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") +
                        System.IO.Path.GetExtension(file1.FileName);
                    string path = Path + filename;
                    file1.SaveAs(Server.MapPath(path));
                    subject.Picture = new Picture()
                    {
                        Id = 0,
                        FileName = filename,
                        FileType = file1.ContentType,
                        Url = path
                    };
                    filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") +
                        System.IO.Path.GetExtension(file2.FileName);
                    path = Path + filename;
                    file2.SaveAs(Server.MapPath(path));
                    subject.ResultPicture = new Picture()
                    {
                        Id = 0,
                        FileName = filename,
                        FileType = file2.ContentType,
                        Url = path
                    };

                    _subjectinfoInfoService.Create(subject);
                    return RedirectToAction("EditGame", new { subjectId = subject.Id });
                }
            }

            ViewBag.Create = true;
            return View("EditGame", model);
        }

        public ActionResult EditGame(int subjectId)
        {
            var data = new SubjectInfoModel();

            var subject = _subjectinfoInfoService.GetSubjectById(subjectId);
            if (subject != null)
            {
                data = subject.ToAdminModel();
                data.Options = subject.Options.Where(o => o.IsValid).Select(o => o.ToAdminModel())
                    .OrderBy(o => o.ResultType).ThenByDescending(o => o.Order).ToList();
            }

            return View(data);
        }

        [HttpPost]
        public ActionResult EditGame(SubjectInfoModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var file1 = Request.Files["Picture"];
                var file2 = Request.Files["ResultPicture"];
                if (model.PictureId == 0 && (file1 == null || !IsImage(file1.ContentType)))
                {
                    model.PictureUrl = "";
                    ModelState.AddModelError("", "please choose a picture");
                }
                if (model.ResultPictureId == 0 && (file2 == null || !IsImage(file2.ContentType)))
                {
                    model.ResultPictureUrl = "";
                    ModelState.AddModelError("", "please choose a result picture");
                }
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var subject = _subjectinfoInfoService.GetSubjectById(model.Id);
                if (subject != null)
                {
                    Picture picture = null;
                    Picture resultPicture = null;

                    if (model.PictureId == 0)
                    {
                        string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") +
                            System.IO.Path.GetExtension(file1.FileName);
                        string path = Path + filename;
                        file1.SaveAs(Server.MapPath(path));
                        picture = subject.Picture;
                        subject.Picture = new Picture()
                        {
                            Id = 0,
                            FileName = filename,
                            FileType = file1.ContentType,
                            Url = path
                        };
                    }

                    if (model.ResultPictureId == 0)
                    {
                        string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") +
                            System.IO.Path.GetExtension(file2.FileName);
                        string path = Path + filename;
                        file2.SaveAs(Server.MapPath(path));
                        resultPicture = subject.ResultPicture;
                        subject.ResultPicture = new Picture()
                        {
                            Id = 0,
                            FileName = filename,
                            FileType = file2.ContentType,
                            Url = path
                        };
                    }

                    subject.Title = model.Title;
                    subject.Description = model.Description;
                    subject.ResultTitle = model.ResultTitle;
                    subject.AdditionNum = model.AdditionNum;
                    subject.Order = model.Order;

                    _subjectinfoInfoService.Update(subject);

                    //delete old picture
                    if (picture != null)
                    {
                        _pictureService.DeletePicture(picture);
                        string path = Server.MapPath(picture.Url);
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                    }
                    if (resultPicture != null)
                    {
                        _pictureService.DeletePicture(resultPicture);
                        string path = Server.MapPath(resultPicture.Url);
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                    }

                    return RedirectToAction("EditGame", new { subjectId = subject.Id });
                }
            }

            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditOption([DataSourceRequest] DataSourceRequest request, SubjectOptionModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var option = _subjectOptionService.GetOptionById(model.Id);
                if (option != null)
                {
                    option.ResultType = model.ResultType;
                    option.Content = model.Content;
                    option.ContentExt = model.ContentExt;
                    option.Order = model.Order;

                    _subjectOptionService.UpdateOption(option);
                }
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult HideOption([DataSourceRequest] DataSourceRequest request, SubjectOptionModel model)
        {
            if (model != null)
            {
                var option = _subjectOptionService.GetOptionById(model.Id);
                if (option != null)
                {
                    _subjectOptionService.Hide(option);
                }
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateOption([DataSourceRequest] DataSourceRequest request, SubjectOptionModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                _subjectOptionService.CreateOption(model.ToEntity());
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}