using AspDemo.DomainModel.common.entity;
using System;

namespace AspDemo.DomainModel.common.command
{
    public class DtoBase<TEntity> where TEntity : EntityBase 
    {
        public Guid? Id { get; set; } 
    }
}
