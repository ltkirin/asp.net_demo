using AspDemo.DomainModel.common.command;
using AspDemo.DomainModel.founder.entity;
using System;

namespace AspDemo.DomainModel.founder.command
{
    public class FounderSerachQuery : SearchQueryBase<Founder>
    {
        public long? Tin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Guid? RelatedCompanyId { get; set; }
    }
}
