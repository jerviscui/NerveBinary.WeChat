using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Picture : BaseEntity
    {
        public virtual string Url { get; set; }

        public virtual string FileName { get; set; }

        public virtual string FileType { get; set; }
    }
}
