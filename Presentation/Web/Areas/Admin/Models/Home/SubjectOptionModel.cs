using Web.Models;

namespace Web.Areas.Admin.Models.Home
{
    public class SubjectOptionModel : BaseAdminModel
    {
        public int ResultType { get; set; }

        public string Content { get; set; }

        public string ContentExt { get; set; }

        public int Order { get; set; }
    }
}