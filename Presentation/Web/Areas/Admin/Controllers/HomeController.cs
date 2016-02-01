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
        private readonly ISubjectInfoService _subjecinfoInfoService;
        private readonly ISubjectOptionService _subjecOptionService;

        public HomeController(ISubjectInfoService subjecinfoInfoService, ISubjectOptionService subjecOptionService)
        {
            _subjecinfoInfoService = subjecinfoInfoService;
            _subjecOptionService = subjecOptionService;
        }

        [AllowAnonymous]
        // GET: Admin/Home
        public ActionResult Index(int pageIndex = 0, int pageSize = 10)
        {
            var data = new PageModel<SubjectInfoModel>();
            var list = _subjecinfoInfoService.GetList(pageIndex, pageSize);

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
            var list = _subjecinfoInfoService.GetList(request.Page - 1, request.PageSize);

            if (list != null)
            {
                //data = list.ToModel<SubjectInfo, SubjectInfoModel>();
                request.Page = 1;
                data = list.Select(o => o.ToAdminModel()).ToDataSourceResult(request);
                data.Total = list.Total;
            }

            return new JsonResult() { Data = data };
        }

        [HttpPost]
        public ActionResult GetOptions([DataSourceRequest]DataSourceRequest request, int subjectId)
        {
            //var data = new PageModel<SubjectOptionModel>();
            var data = new DataSourceResult();
            var list = _subjecOptionService.GetOptions(subjectId, request.Page - 1, request.PageSize);

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
                _subjecinfoInfoService.Hide(model.Id);
            }

            return GridGet(request);
        }

        public ActionResult NewGame()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewGame(SubjectInfoModel model)
        {
            return View();
        }

        public ActionResult EditGame(int subjectId)
        {
            var data = new SubjectInfoModel();

            var subject = _subjecinfoInfoService.GetSubjectById(subjectId);
            if (subject != null)
            {
                data = subject.ToAdminModel();
                data.Options = subject.Options.Select(o => o.ToAdminModel()).ToList();
            }

            return View(data);
        }

        [HttpPost]
        public ActionResult EditGame(SubjectInfoModel model)
        {
            return View();
        }
    }
}