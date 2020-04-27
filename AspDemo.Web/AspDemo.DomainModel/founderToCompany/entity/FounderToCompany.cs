using AspDemo.DomainModel.common.entity;
using AspDemo.DomainModel.company.entity;
using AspDemo.DomainModel.founder.entity;
using System;

namespace AspDemo.DomainModel.founderToCompany.entity
{
    public class FounderToCompany : EntityBase
    {
        public FounderToCompany() { }

        public FounderToCompany(Company company, Founder founder)
        {
            Company = company;
            CompanyId = company.Id;
            Founder = founder;
            FounderId = founder.Id;
        }

        public Guid CompanyId { get; set; }

        public Company Company { get; set; }

        public Guid FounderId { get; set; }

        public Founder Founder { get; set; }
    }
}
