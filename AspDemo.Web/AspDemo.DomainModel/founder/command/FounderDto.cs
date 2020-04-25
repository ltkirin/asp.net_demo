using AspDemo.DomainModel.common.command;
using AspDemo.DomainModel.founder.entity;
using System;
using System.Collections.Generic;

namespace AspDemo.DomainModel.founder.command
{
    public class FounderDto : DtoBase<Founder>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public long Tin { get; set; }
        public IList<Guid> RelatedCompaniesIds { get; set; }
    }
}
