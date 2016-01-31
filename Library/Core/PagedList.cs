using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int total)
        {
            Total = total;
            CurrenIndex = pageIndex;
            PageSize = pageSize;
            TotalPage = (Total + PageSize - 1)/PageSize;
            HasNext = CurrenIndex < TotalPage - 1;
            HasPrev = CurrenIndex > 0;

            this.AddRange(source);
        }

        public PagedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            Total = source.Count();
            CurrenIndex = pageIndex;
            PageSize = pageSize;
            TotalPage = (Total + PageSize - 1) / PageSize;
            HasNext = CurrenIndex < TotalPage - 1;
            HasPrev = CurrenIndex > 0;

            this.AddRange(source.Skip(pageIndex * pageSize).Take(pageSize));
        }

        public int CurrenIndex { get; set; }

        public int PageSize { get; set; }

        public int Total { get; set; }

        public int TotalPage { get; set; }

        public bool HasNext { get; set; }

        public bool HasPrev { get; set; }
    }
}
