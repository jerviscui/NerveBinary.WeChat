using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IPagedList<T> : IList<T>
    {
        int CurrenIndex { get; set; }

        int PageSize { get; set; }

        int Total { get; set; }

        int TotalPage { get; set; }

        bool HasNext { get; set; }

        bool HasPrev { get; set; }
    }
}
