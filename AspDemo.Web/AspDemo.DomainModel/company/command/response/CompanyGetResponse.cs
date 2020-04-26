﻿using AspDemo.DomainModel.common.command.response;
using AspDemo.DomainModel.company.model;

namespace AspDemo.DomainModel.company.command.response
{
    public class CompanyGetResponse : ResponseBase
    {
        public CompanyGetModel Model { get; set; }
    }
}
