using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.Game
{
    public class SubjectResultModel : BaseModel
    {
        public SubjectResultModel()
        {
            Options = new List<SubjectOptionModel>();
        }

        public int SubjectId { get; set; }

        public string ResultTitle { get; set; }
        
        public string PictureUrl { get; set; }

        public DateTime CreateOnUtc { get; set; }

        public IList<SubjectOptionModel> Options { get; set; }
    }
}