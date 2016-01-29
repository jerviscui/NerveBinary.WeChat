using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace DataService.Map
{
    public class PictureMap : BaseMap<Picture>
    {
        public PictureMap()
            : base("Picture")
        {
            this.Property(o => o.Url).IsRequired();
        }
    }
}
