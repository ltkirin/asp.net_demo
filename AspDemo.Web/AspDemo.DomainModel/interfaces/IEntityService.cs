using AspDemo.DomainModel.common.command;
using AspDemo.DomainModel.common.entity;
using System;
using System.Collections.Generic;

namespace AspDemo.DomainModel.interfaces
{
    public interface IEntityService<TEntity> where TEntity : EntityBase
    {
        void Create(DtoBase<TEntity> command);
        void Update(DtoBase<TEntity> command);
        void Delete(Guid id);
        void Restore(Guid id);
        TEntity FindById(Guid id);
        IList<TEntity> GetAll(bool deleted);
        IList<TEntity> Search(SearchQueryBase<TEntity> searchQuery);
    }
}
