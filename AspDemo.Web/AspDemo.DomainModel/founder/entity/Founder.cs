using AspDemo.DomainModel.common.entity;
using System.ComponentModel.DataAnnotations;

namespace AspDemo.DomainModel.founder.entity
{
    public class Founder : TaxesRelatedEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}
