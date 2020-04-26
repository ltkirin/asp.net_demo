using AspDemo.DomainModel.common.model;
using System.Collections.Generic;

namespace AspDemo.DomainModel.company.model
{
    public class CompanyGetModel : EntityModelBase
    {
        public string Title { get; set; }

        public long Tin { get; set; }

        public IList<ListItemModel> Founders { get; set; } = new List<ListItemModel>();

        public int CompanyType { get; set; }
    }
}
