using AspDemo.DomainModel.common.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspDemo.DomainModel.common.command.response
{
    public class ListGetResponse : ResponseBase
    {
        public IList<ListItemModel> Items { get; } = new List<ListItemModel>();
    }
}
