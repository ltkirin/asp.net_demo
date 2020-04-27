using System;
using AspDemo.DomainModel.common.command.response;
using AspDemo.DomainModel.company.command.request;
using AspDemo.DomainModel.company.command.response;
using AspDemo.DomainModel.service;
using AspDemo.Web.common;
using Microsoft.AspNetCore.Mvc;

namespace AspDemo.Web.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesApiController : ApiControllerBase
    {
        public CompaniesApiController(DataProvider dataProvider) : base(dataProvider)
        {
        }

        [HttpPost]
        public ResponseBase Create(CompanyPostRequest request)
        {
            return Query(() =>
            {
                return dataManager.CreateCompany(request.Model);
            });
        }

        [HttpGet]
        public ListGetResponse GetAll(bool deleted = false, int pageNumber = 1, int pageSize = 100)
        {
            return Query(() =>
            {
                return dataManager.GetAllCompanies(deleted, pageNumber, pageSize);
            });
        }

        [Route("{id}")]
        [HttpGet]
        public CompanyGetResponse GetFullInfo(Guid id)
        {
            return Query(() =>
            {
                return dataManager.GetCompanyFullModel(id);
            });
        }

        [HttpPut]
        public ResponseBase Update(CompanyPutRequest request)
        {
            return Query(() =>
            {
                return dataManager.UpdateCompany(request.Model);
            });
        }

        [HttpDelete]
        public ResponseBase Delete(Guid id)
        {
            return Query(() =>
            {
                return dataManager.DeleteCompany(id);
            });
        }
    }

}
