using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using Core.Domain;
using Kendo.Mvc.Extensions;
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
                data.Data.AddRange(list.Select(o => new SubjectInfoModel()
                {
                    Description = o.Description, Id = o.Id, Order = o.Order, PictureId = o.PictureId, PictureUrl = o.Picture.Url,
                    ResultPictureId = o.ResultPictureId, ResultPictureUrl = o.ResultPicture.Url
                }));
            }

            return View(data);
        }
    }
}