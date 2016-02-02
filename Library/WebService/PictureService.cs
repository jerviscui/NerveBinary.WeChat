using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using DataService;

namespace WebService
{
    public class PictureService : IPictureService
    {
        private readonly IRepository<Picture> _pictureRepository;

        public PictureService(IRepository<Picture> pictureRepository)
        {
            _pictureRepository = pictureRepository;
        }

        public void DeletePicture(Picture picture)
        {
            _pictureRepository.Delete(picture);
        }
    }
}
