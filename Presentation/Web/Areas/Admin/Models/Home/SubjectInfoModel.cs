
namespace Web.Areas.Admin.Models.Home
{
    public class SubjectInfoModel : BaseAdminModel
    {
        public string Title { get; set; }
               
        public string Description { get; set; }
               
        public int Order { get; set; }
               
        public string PictureUrl { get; set; }

        public int PictureId { get; set; }

        public string ResultPictureUrl { get; set; }

        public int ResultPictureId { get; set; }
    }
}