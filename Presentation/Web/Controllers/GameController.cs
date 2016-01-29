using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Domain;
using Web.Infrastructure;
using Web.Models.Game;
using WebService;

namespace Web.Controllers
{
    public class GameController : Controller
    {
        private readonly ISubjectInfoService _subjectInfoService;
        private readonly ISubjectOptionService _subjectOptionService;
        private readonly ISubjectResultService _subjectResultService;

        public GameController(ISubjectInfoService subjectInfoService, ISubjectOptionService subjectOptionService, ISubjectResultService subjectResultService)
        {
            _subjectInfoService = subjectInfoService;
            _subjectOptionService = subjectOptionService;
            _subjectResultService = subjectResultService;
        }

        // GET: Game
        public ActionResult Index()
        {
            var model = new List<SubjectInfoModel>();

            var str = ConfigurationManager.AppSettings["GameIndexCount"];
            int count = 20;
            if (!string.IsNullOrEmpty(str) && int.TryParse(str, out count))
            {
                ;
            }
            var list = _subjectInfoService.GetList(count);
            if (list != null)
            {
                model.AddRange(list.Select(o => o.ToModel()));
            }

            return View(model);
        }

        public ActionResult Result(int subjectId, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                ModelState.AddModelError("", "请输入姓名");
            }

            var subject = _subjectInfoService.GetSubjectById(subjectId);
            if (subject == null)
            {
                ModelState.AddModelError("", "题目不存在");
            }

            var model = new SubjectResultModel();

            if (ModelState.IsValid)
            {
                var result = _subjectResultService.GetResultByKey(subject.Id, name);
                if (result == null)
                {
                    var random = new Random((int) DateTime.Now.Ticks);
                    result = new SubjectResult()
                    {
                        Subject = subject,
                        Key = name,
                        Options = new List<SubjectOption>(),
                        ResultPictureId = subject.ResultPictureId
                    };

                    var options = subject.Options;
                    var group = options.GroupBy(o => o.ResultType);
                    foreach (var item in group)
                    {
                        result.Options.Add(item.ElementAt(random.Next(item.Count())));
                    }

                    //create picture

                    _subjectResultService.Add(result);
                    
                }

                model = result.ToModel();
                model.ResultTitle = name + subject.ResultTitle;
            }

            return View(model);
        }

        public ActionResult Detail(int subjectId)
        {
            var model = new SubjectInfoModel();
            var info = _subjectInfoService.GetSubjectById(subjectId);

            if (info != null)
            {
                model = info.ToModel();
                model.Total = info.AdditionNum + _subjectResultService.GetResultCount(info.Id);
            }

            return View(model);
        }

        public PartialViewResult HotGames(int count = 2)
        {
            var model = new List<SubjectInfoModel>();

            var list = _subjectInfoService.GetList(2);
            if (list != null)
            {
                model.AddRange(list.Select(o => o.ToModel()));
            }

            return PartialView(model);
        }
    }
}