using AspDemo.DomainModel.common.entity;
using AspDemo.DomainModel.context;
using AspDemo.DomainModel.extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspDemo.DomainModel.common.service
{
    public class ServiceBase
    {
        protected readonly CompanyDbContext context;
        public ServiceBase(CompanyDbContext context)
        {
            this.context = context;
        }

        protected void PerformCreate<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            entity.Id = Guid.NewGuid();
            entity.CreationDate = DateTime.Now;
            entity.ModifiedDate = entity.CreationDate;
            context.GetDbSet<TEntity>().Add(entity);
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

        protected TEntity GetById<TEntity>(Guid id) where TEntity: EntityBase
        {
            
            return context
                .GetDbSet<TEntity>()
                .FirstOrDefault(e => e.Id == id);
        }

        protected IList<TEntity> PerformGetAll<TEntity>(bool deleted, int pageNumber, int pagesize) where TEntity : EntityBase
        {
            return context
                .GetDbSet<TEntity>()
                .Where(e => e.IsDeleted == deleted)
                .Page(pageNumber, pagesize)
                .ToArray();
        }
    }
}
