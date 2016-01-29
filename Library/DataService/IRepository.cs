using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace DataService
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Table { get; }

        void Add(T model);

        void Update(T model);

        void Hide(T model);

        void Delete(T model);
    }
}
