using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace DataService
{
    public interface IDbContext
    {
        DbSet<T> Set<T>() where T : BaseEntity;

        DbEntityEntry Entry<T>(T entity) where T : BaseEntity;

        int SaveChanges();
    }
}
