using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class SubjectOption : BaseEntity
    {
        public virtual int ResultType { get; set; }

        public virtual string ContentExt { get; set; }

        public virtual string Content { get; set; }

        public virtual int Order { get; set; }

        public virtual int SubjectId { get; set; }

        public virtual SubjectInfo Subject { get; set; }
    }
}
