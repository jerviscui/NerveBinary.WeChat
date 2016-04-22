using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace WebService
{
    public interface IPictureService
    {
        void DeletePicture(Picture picture);
    }
}
