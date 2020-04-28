using AspDemo.DomainModel.common.model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspDemo.DomainModel.company.model
{
    public class CompanyFullModel : EntityModelBase, IValidatableObject
    {
        private const int TinLength = 12;
        public string Title { get; set; }

        public long Tin { get; set; }

        public IList<Guid> FoundersIds { get; set; } = new List<Guid>();
    
        public int CompanyType { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            if (string.IsNullOrEmpty(Title))
            {
                results.Add(new ValidationResult("Title is required!"));
            }
            if (Tin.ToString().Length != TinLength)
            {
                results.Add(new ValidationResult("Incorrect TIN!"));
            }
            if(CompanyType == 0 && FoundersIds.Count > 1)
            {
                results.Add(new ValidationResult("Individual Entrepreneur can't have more tha 1 Founder!"));
            }
            return results;
        }
    }
}
