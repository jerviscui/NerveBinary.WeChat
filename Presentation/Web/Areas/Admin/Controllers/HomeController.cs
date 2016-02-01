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

        public HomeController(ISubjectInfoService subjecinfoInfoService)
        {
            _subjecinfoInfoService = subjecinfoInfoService;
        }

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

        public ActionResult GridGet([DataSourceRequest]DataSourceRequest request)
        {
            var data = new PageModel<SubjectInfoModel>();
            var list = _subjecinfoInfoService.GetList(request.Page - 1, request.PageSize);

            if (list != null)
            {
                data = list.ToModel<SubjectInfo, SubjectInfoModel>();
                data.Data.AddRange(list.Select(o => o.ToAdminModel()));
            }

            return new JsonResult() { Data = data };
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
    }
}