using System.Collections.Generic;

namespace Web.Areas.Admin.Models.Home
{
    public class SubjectResultModel : BaseAdminModel
    {
        public int SubjectId { get; set; }

        public string ResultTitle { get; set; }
        
        public string PictureUrl { get; set; }

        public IList<SubjectOptionModel> Options { get; set; }
    }
}