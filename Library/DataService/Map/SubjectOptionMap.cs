using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace DataService.Map
{
    public class SubjectOptionMap : BaseMap<SubjectOption>
    {
        public SubjectOptionMap()
            : base("SubjectOption")
        {
            this.Property(o => o.ResultType).IsRequired();
            this.Property(o => o.Content).IsRequired();
        }
    }
}
