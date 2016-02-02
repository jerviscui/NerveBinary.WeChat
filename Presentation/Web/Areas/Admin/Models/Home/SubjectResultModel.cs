using System;
using System.Collections.Generic;
using Core.Domain;

namespace Web.Areas.Admin.Models.Home
{
    public class SubjectResultModel : BaseAdminModel
    {
        public SubjectResultModel()
        {
            Options = new List<SubjectOptionModel>();
        }

        public string Key { get; set; }

        public int SubjectId { get; set; }
        
        public DateTime CreateOnUtc { get; set; }

        public int ResultPictureId { get; set; }

        public string ResultPictureUrl { get; set; }

        public IList<SubjectOptionModel> Options { get; set; }
    }
}