using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using DataService.Map;

namespace DataService
{
    public class EFDbContext : DbContext, IDbContext
    {
        public EFDbContext()
            : base("DefaultConnection")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new BaseMap());
            modelBuilder.Configurations.Add(new PictureMap());
            modelBuilder.Configurations.Add(new SubjectInfoMap());
            modelBuilder.Configurations.Add(new SubjectOptionMap());
            modelBuilder.Configurations.Add(new SubjectResultMap());

            base.OnModelCreating(modelBuilder);
        }

        public new DbSet<T> Set<T>() where T : BaseEntity
        {
            return base.Set<T>();
        }

        public new DbEntityEntry Entry<T>(T entity) where T : BaseEntity
        {
            return base.Entry(entity);
        }

        public int SaveChanges()
        {
            try
            {
                int i = base.SaveChanges();
                return i;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ((IObjectContextAdapter)this).ObjectContext.Refresh(RefreshMode.ClientWins, ex.Entries);
                int i = base.SaveChanges();
                return i;
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
            catch
            {
                throw;
            }

            return 0;
        }
    }
}
