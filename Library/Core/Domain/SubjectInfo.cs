using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class SubjectInfo : BaseEntity
    {
        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        public virtual int Order { get; set; }

        public virtual int AdditionNum { get; set; }

        public virtual string ResultTitle { get; set; }

        public virtual int PictureId { get; set; }

        public virtual Picture Picture { get; set; }
        
    }
}
