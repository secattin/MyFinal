using Core.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity : class , IEntites, new()
        where TContext : DbContext, new()

    {
        public void Add(TEntity entity)
        {
            // using bittiği anda belleği temizler.
            // IDisposable pattern implemente eden bir nesne belleği temizler.
            using (TContext contex = new TContext())
            {
                var addedEntity = contex.Entry(entity); // referansı yakala
                addedEntity.State = EntityState.Added; // ekleme yapılacak
                contex.SaveChanges(); // ekleme işlemini yap
            }

        }

        public void Delete(TEntity entity)
        {
            using (TContext contex = new TContext())
            {
                var addedEntity = contex.Entry(entity); // referansı yakala
                addedEntity.State = EntityState.Deleted; // silme  yapılacak
                contex.SaveChanges(); // ekleme işlemini yap
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GettAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext contex = new TContext())
            {
                return filter == null ? 
                    contex.Set<TEntity>().ToList() 
                    :contex.Set<TEntity>().ToList();

            }
        }

        public void Update(TEntity entity)
        {
            using (TContext contex = new TContext())
            {
                var updatedEntity = contex.Entry(entity); // referansı yakala
                updatedEntity.State = EntityState.Modified; // güncelleme yapılacak
                contex.SaveChanges(); // ekleme işlemini yap
            }
        }

    }
}
