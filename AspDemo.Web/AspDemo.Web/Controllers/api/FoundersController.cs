using AspDemo.DomainModel.common.command.response;
using AspDemo.DomainModel.founder.command.request;
using AspDemo.DomainModel.founder.command.response;
using AspDemo.DomainModel.service;
using AspDemo.Web.common;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AspDemo.Web.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoundersController : ApiControllerBase
    {
        public FoundersController(DataManager dataManager) : base(dataManager)
        {
        }

        [HttpPost]
        public ResponseBase Create(FounderPostRequest request)
        {
            return Query(() =>
            {
                return dataManager.CreateFounder(request.Model);
            });
        }

        [HttpGet]
        public ListGetResponse GetAll(bool deleted = false, int pageNumber = 1, int pageSize = 100)
        {
            return Query(() =>
            {
                return dataManager.GetAllFounders(deleted, pageNumber, pageSize);
            });
        }
        [Route("{id}")]
        [HttpGet]
        public FounderGetResponse GetFullInfo(Guid id)
        {
            return Query(() =>
            {
                return dataManager.GetFounderFullModel(id);
            });
        }

        [HttpPut]
        public ResponseBase Update(FounderPutRequest request)
        {
            return Query(() =>
            {
                return dataManager.UpdateFounder(request.Model);
            });
        }

        [HttpDelete]
        public ResponseBase Delete(Guid id)
        {
            return Query(() =>
            {
                return dataManager.DeleteFounder(id);
            });
        }
    }
}