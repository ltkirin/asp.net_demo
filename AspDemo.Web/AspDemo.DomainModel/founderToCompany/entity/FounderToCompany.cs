using AspDemo.DomainModel.common.entity;
using AspDemo.DomainModel.company.entity;
using AspDemo.DomainModel.founder.entity;

namespace AspDemo.DomainModel.founderToCompany.entity
{
    public class FounderToCompany : EntityBase
    {
        public Company Company { get; set; }

        public Founder Founder { get; set; }
    }
}
