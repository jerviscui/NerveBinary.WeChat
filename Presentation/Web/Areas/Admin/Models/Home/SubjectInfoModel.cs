
using System.Collections.Generic;

namespace Web.Areas.Admin.Models.Home
{
    public class SubjectInfoModel : BaseAdminModel
    {
        public SubjectInfoModel()
        {
            Options = new List<SubjectOptionModel>();
        }

        public string Title { get; set; }
               
        public string Description { get; set; }
               
        public int Order { get; set; }
               
        public string PictureUrl { get; set; }

        public int PictureId { get; set; }

        public string ResultPictureUrl { get; set; }

        public int ResultPictureId { get; set; }

        public IList<SubjectOptionModel> Options { get; set; }
    }
}