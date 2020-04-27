using AspDemo.DomainModel.common.model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspDemo.DomainModel.company.model
{
    public class CompanyFullModel : EntityModelBase
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public long Tin { get; set; }

        public IList<Guid> FoundersIds { get; set; }
        [Required]
        public int CompanyType { get; set; }
    }
}
