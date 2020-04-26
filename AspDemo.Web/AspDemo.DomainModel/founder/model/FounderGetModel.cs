using AspDemo.DomainModel.common.model;
using System.Collections.Generic;

namespace AspDemo.DomainModel.founder.model
{
    public class FounderGetModel : EntityModelBase
    {
        public long Tin { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public IList<ListItemModel> Companies { get; set; } = new List<ListItemModel>();
    }
}
