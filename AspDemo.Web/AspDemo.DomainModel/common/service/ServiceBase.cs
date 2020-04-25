using AspDemo.DomainModel.common.entity;
using AspDemo.DomainModel.context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspDemo.DomainModel.common.service
{
    public class ServiceBase
    {
        protected void PerformCreate<TEntity>(TEntity entity, CompanyDbContext dbContext) where TEntity : EntityBase
        {
            entity.CreationDate = DateTime.Now;
            dbContext.GetDbSet<TEntity>().Add(entity);
        }

        protected void PerformDelete<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            entity.IsDeleted = true;
            PerformUpdate(entity);
        }

        protected void PerformRestore<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            entity.IsDeleted = false;
            PerformUpdate(entity);
        }

        protected void PerformUpdate<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            entity.ModifiedDate = DateTime.Now;
        }

        protected TEntity GetById<TEntity>(Guid id, CompanyDbContext dbContext = null) where TEntity: EntityBase
        {
            dbContext = dbContext ?? new CompanyDbContext();
            return dbContext
                .GetDbSet<TEntity>()
                .FirstOrDefault(e => e.Id == id);
        }

        protected IList<TEntity> PerformGetAll<TEntity>(bool deleted) where TEntity : EntityBase
        {
            return new CompanyDbContext()
                .GetDbSet<TEntity>()
                .Where(e => e.IsDeleted == deleted)
                .ToArray();
        }
    }
}
