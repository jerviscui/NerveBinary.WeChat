using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class SubjectResult : BaseEntity
    {
        public virtual int ResultType { get; set; }
        
        public virtual string Content { get; set; }

        public virtual int Order { get; set; }
        
        public virtual int PictureId { get; set; }

        public virtual Picture Picture { get; set; }
    }
}
