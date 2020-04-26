using AspDemo.DomainModel.common.model;
using System;
using System.Collections.Generic;

namespace AspDemo.DomainModel.company.model
{
    public class CompanyPutModel : EntityModelBase
    {
        public string Title { get; set; }

        public long Tin { get; set; }

        public IList<Guid> FoundersIds { get; set; } = new List<Guid>();

        public int CompanyType { get; set; }
    }
}
