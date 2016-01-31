using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Areas.Admin.Models
{
    public class PageModel<T>
    {
        public PageModel()
        {
            Data = new List<T>();
        }

        public IList<T> Data { get; set; }

        public int CurrenIndex { get; set; }

        public int PageSize { get; set; }

        public int Total { get; set; }

        public int TotalPage { get; set; }

        public bool HasNext { get; set; }

        public bool HasPrev { get; set; }
    }
}
