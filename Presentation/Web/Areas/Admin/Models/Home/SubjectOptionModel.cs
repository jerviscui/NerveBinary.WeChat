using System.ComponentModel.DataAnnotations;
using Web.Models;

namespace Web.Areas.Admin.Models.Home
{
    public class SubjectOptionModel : BaseAdminModel
    {
        [Required]
        public int ResultType { get; set; }

        public string ContentExt { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Content { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public int SubjectId { get; set; }
    }
}