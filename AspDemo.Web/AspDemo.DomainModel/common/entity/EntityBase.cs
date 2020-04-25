using System;
using System.ComponentModel.DataAnnotations;

namespace AspDemo.DomainModel.common.entity
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public bool IsDeleted { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
