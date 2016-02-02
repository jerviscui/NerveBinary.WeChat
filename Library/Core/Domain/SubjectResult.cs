using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class SubjectResult : BaseEntity
    {
        public virtual string Key { get; set; }

        public virtual int SubjectId { get; set; }

        public virtual SubjectInfo Subject { get; set; }

        public virtual DateTime CreateOnUtc { get; set; }

        public virtual int ResultPictureId { get; set; }

        public virtual Picture ResultPicture { get; set; }
        
        public virtual ICollection<SubjectOption> Options { get; set; }
    }
}
