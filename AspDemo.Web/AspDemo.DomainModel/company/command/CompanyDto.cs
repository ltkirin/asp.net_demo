using AspDemo.DomainModel.common.command;
using AspDemo.DomainModel.company.entity;
using AspDemo.DomainModel.company.enums;
using System;
using System.Collections.Generic;

namespace AspDemo.DomainModel.company.command
{
    public class CompanyDto : DtoBase<Company>
    {
        public string Title { get; set; }

        public CompanyType CompanyType { get; set; }

        public long Tin { get; set; }

        public IList<Guid> FoundersIds { get; set; }
    }
}
