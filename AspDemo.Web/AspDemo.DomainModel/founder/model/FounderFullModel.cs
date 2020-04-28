using AspDemo.DomainModel.common.model;
using AspDemo.DomainModel.company.model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;

namespace AspDemo.DomainModel.founder.model
{
    public class FounderFullModel : EntityModelBase, IValidatableObject
    {
        private const int TinLength = 12;

        public long Tin { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public List<Guid> CompaniesIds { get; set; } = new List<Guid>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            if(string.IsNullOrEmpty(LastName))
            {
                results.Add(new ValidationResult("Last name is required!"));
            }
            if (string.IsNullOrEmpty(FirstName))
            {
                results.Add(new ValidationResult("First name is required!"));
            }
            if(Tin.ToString().Length != TinLength)
            {
                results.Add(new ValidationResult("Incorrect TIN!"));
            }
            return results;
        }
    }
}
