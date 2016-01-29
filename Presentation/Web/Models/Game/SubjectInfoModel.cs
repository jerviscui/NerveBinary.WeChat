using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.Game
{
    public class SubjectInfoModel : BaseModel
    {
        public string Title { get; set; }
               
        public string Description { get; set; }
               
        public int Order { get; set; }
               
        public int Total { get; set; }
               
        public string PictureUrl { get; set; }
    }
}