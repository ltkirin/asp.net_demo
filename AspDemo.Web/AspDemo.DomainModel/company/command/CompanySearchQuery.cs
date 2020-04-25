using AspDemo.DomainModel.common.command;
using AspDemo.DomainModel.company.entity;
using AspDemo.DomainModel.company.enums;
using System;

namespace AspDemo.DomainModel.company.command
{
    public class CompanySearchQuery : SearchQueryBase<Company>
    {
        public string Title { get; set; }
        public CompanyType? CompanyType { get; set; }
        public long? Tin { get; set; }

        public Guid? FounderId { get; set; }
    }
}
