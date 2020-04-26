﻿using AspDemo.DomainModel.common.command.response;
using AspDemo.DomainModel.founder.model;

namespace AspDemo.DomainModel.founder.command.response
{
    public class FounderGetResponse : ResponseBase
    {
        public FounderGetModel Model { get; set; }
    }
}
