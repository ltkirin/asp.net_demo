using System.ComponentModel.DataAnnotations;

namespace AspDemo.DomainModel.common.entity
{
    public abstract class TaxesRelatedEntity : EntityBase
    {
        [Required]
        public long Tin { get; set; }
    }
}
