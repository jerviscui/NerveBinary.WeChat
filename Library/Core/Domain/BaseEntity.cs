using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class BaseEntity
    {
        public virtual int Id { get; set; }
               
        public virtual byte[] Timespan { get; set; }
               
        public virtual bool IsValid { get; set; }
    }
}
