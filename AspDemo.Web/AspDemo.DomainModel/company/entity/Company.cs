using AspDemo.DomainModel.common.entity;
using AspDemo.DomainModel.company.enums;
using System.ComponentModel.DataAnnotations;

namespace AspDemo.DomainModel.company.entity
{
    public class Company : TaxesRelatedEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public CompanyType Type { get; set; }
    }
}
