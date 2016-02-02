using System;
using System.Collections.Generic;
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

        public HomeController(ISubjectInfoService subjectinfoInfoService, ISubjectOptionService subjectOptionService, ISubjectResultService subjectResultService)
        {
            _subjectinfoInfoService = subjectinfoInfoService;
            _subjectOptionService = subjectOptionService;
            _subjectResultService = subjectResultService;
        }

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
                _subjectinfoInfoService.Create(model.ToEntity());
                return RedirectToAction("EditGame", new { subjectId = model.Id });
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
                var subject = _subjectinfoInfoService.GetSubjectById(model.Id);
                if (subject != null)
                {
                    subject.Title = model.Title;
                    subject.Description = model.Description;
                    subject.ResultTitle = model.ResultTitle;
                    subject.AdditionNum = model.AdditionNum;
                    subject.Order = model.Order;

                    _subjectinfoInfoService.Update(subject);
                    model.Options = subject.Options.Where(o => o.IsValid).Select(o => o.ToAdminModel())
                        .OrderBy(o => o.ResultType).ThenByDescending(o => o.Order).ToList();
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