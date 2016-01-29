using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace DataService
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDbContext _dbContext;

        public Repository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Table { get { return _dbContext.Set<T>(); } }

        public void Add(T model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            _dbContext.Set<T>().Add(model);
            this.Save();
        }

        public void Update(T model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            _dbContext.Entry(model).State = EntityState.Modified;
            this.Save();
        }

        public void Hide(T model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            model.IsValid = false;
            _dbContext.Entry(model).State = EntityState.Modified;
            this.Save();
        }

        public void Delete(T model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            model.IsValid = false;
            _dbContext.Set<T>().Remove(model);
            this.Save();
        }

        private void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
