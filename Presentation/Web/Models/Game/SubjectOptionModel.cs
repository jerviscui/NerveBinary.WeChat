using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.Game
{
    public class SubjectOptionModel : BaseModel
    {
        public int ResultType { get; set; }

        public string Content { get; set; }

        public string ContentExt { get; set; }

        public int Order { get; set; }
    }
}