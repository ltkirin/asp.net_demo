﻿using AspDemo.DomainModel.common.model;
using AspDemo.DomainModel.company.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspDemo.DomainModel.founder.model
{
    public class FounderPutModel : EntityModelBase
    {
        public long Tin { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public List<ListItemModel> Companies { get; set; } = new List<ListItemModel>();
    }
}
