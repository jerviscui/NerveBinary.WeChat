
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Areas.Admin.Models.Home
{
    public class SubjectInfoModel : BaseAdminModel
    {
        public SubjectInfoModel()
        {
            Options = new List<SubjectOptionModel>();
        }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public int AdditionNum { get; set; }

        public string ResultTitle { get; set; }
               
        public string PictureUrl { get; set; }

        [Required]
        public int PictureId { get; set; }

        public string ResultPictureUrl { get; set; }

        [Required]
        public int ResultPictureId { get; set; }

        public IList<SubjectOptionModel> Options { get; set; }
    }
}