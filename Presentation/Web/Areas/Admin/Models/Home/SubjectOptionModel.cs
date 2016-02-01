using Web.Models;

namespace Web.Areas.Admin.Models.Home
{
    public class SubjectOptionModel : BaseAdminModel
    {
        public virtual int ResultType { get; set; }

        public virtual string ContentExt { get; set; }

        public virtual string Content { get; set; }

        public virtual int Order { get; set; }

        public virtual int SubjectId { get; set; }
    }
}