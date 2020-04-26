using AspDemo.DomainModel.common.command.response;
using AspDemo.DomainModel.company.command;
using AspDemo.DomainModel.company.command.response;
using AspDemo.DomainModel.company.entity;
using AspDemo.DomainModel.company.enums;
using AspDemo.DomainModel.company.model;
using AspDemo.DomainModel.founder.command;
using AspDemo.DomainModel.founder.command.response;
using AspDemo.DomainModel.founder.entity;
using AspDemo.DomainModel.founder.model;
using AspDemo.DomainModel.interfaces;
using AspDemo.DomainModel.service.converter;
using System;
using System.Collections.Generic;

namespace AspDemo.DomainModel.service
{
    public class DataManager
    {
        private readonly IEntityService<Company> companyService;
        private readonly IEntityService<Founder> founderService;
        private readonly EntityConverter entityConverter;

        public DataManager(IEntityService<Company> companyService, 
            IEntityService<Founder> founderService, EntityConverter entityConverter)
        {
            this.companyService = companyService;
            this.founderService = founderService;
            this.entityConverter = entityConverter;
        }

        public ResponseBase CreateCompany(CompanyPostModel model)
        {
            companyService.Create(entityConverter.GetDto(model));
            return new ResponseBase();
        }

        public ResponseBase CreateFounder(FounderPostModel model)
        {
            founderService.Create(entityConverter.GetDto(model));
            return new ResponseBase();
        }

        public ListGetResponse GetAllCompanies(bool deleted, int pageNumber, int pageSize)
        {
            ListGetResponse response = new ListGetResponse();
            IList<Company> companies = companyService.GetAll(deleted, pageNumber, pageSize);
            foreach (Company company in companies)
            {
                response.Items.Add(entityConverter.GetListItemModel(company));
            }
            return response;
        }

        public ListGetResponse GetAllFounders(bool deleted, int pageNumber, int pageSize)
        {
            ListGetResponse response = new ListGetResponse();
            IList<Founder> founders = founderService.GetAll(deleted, pageNumber, pageSize);
            foreach (Founder founder in founders)
            {
                response.Items.Add(entityConverter.GetListItemModel(founder));
            }
            return response;
        }

        public CompanyGetResponse GetCompanyFullModel(Guid id)
        {
            Company company = companyService.FindById(id);
            IList<Founder> founders = founderService.Search(
                new FounderSerachQuery()
                {
                    RelatedCompanyId = company.Id
                });
            return new CompanyGetResponse()
            {
                Model = entityConverter.GetModel(company, founders)
            };
        }

        public FounderGetResponse GetFounderFullModel(Guid id)
        {
            Founder founder = founderService.FindById(id);
            IList<Company> companies = companyService.Search(
                new CompanySearchQuery()
                {
                    FounderId = founder.Id
                });
            return new FounderGetResponse()
            {
                Model = entityConverter.GetModel(founder, companies)
            };
        }

        public ListGetResponse SearchCompanies(long? tin, int? companyType, string title, 
            Guid? founderId, int pageSize, int pageNumber)
        {
            ListGetResponse response = new ListGetResponse();

            CompanyType? type = null;
            if (companyType != null)
            {
                type = (CompanyType)companyType.Value;
            }
            CompanySearchQuery query = new CompanySearchQuery()
            {
                Tin = tin ?? null,
                Title = title ?? string.Empty,
                CompanyType = type,
                FounderId = founderId ?? null,
                PageSize = pageSize,
                PageNumber = pageNumber
            };

            foreach (Company company in companyService.Search(query))
            {
                response.Items.Add(entityConverter.GetListItemModel(company));
            }

            return response;
        }

        public ListGetResponse SearchFounders(long? tin, string lastName, string firstName, string middlName, 
            Guid? companyId, int pageSize, int pageNumber)
        {
            ListGetResponse response = new ListGetResponse();

            FounderSerachQuery query = new FounderSerachQuery()
            {
                Tin = tin ?? null,

                LastName = (string.IsNullOrEmpty(lastName))
                ? string.Empty
                : lastName,

                FirstName = (string.IsNullOrEmpty(firstName))
                ? string.Empty
                : firstName,

                MiddleName = (string.IsNullOrEmpty(firstName))
                ? string.Empty
                : firstName,

                RelatedCompanyId = companyId ?? null,

                PageSize = pageSize,
                PageNumber = pageNumber
            };

            foreach (Founder founder in founderService.Search(query))
            {
                response.Items.Add(entityConverter.GetListItemModel(founder));
            }

            return response;
        }

        public ResponseBase UpdateCompany(CompanyPutModel model)
        {
            companyService.Update(entityConverter.GetDto(model));
            return new ResponseBase();
        }

        public ResponseBase UpdateFounder(FounderPutModel model)
        {
            founderService.Update(entityConverter.GetDto(model));
            return new ResponseBase();
        }

        public ResponseBase DeleteCompany(Guid id)
        {
            companyService.Delete(id);
            return new ResponseBase();
        }

        public ResponseBase DeleteFounder(Guid id)
        {
            founderService.Delete(id);
            return new ResponseBase();
        }

        public ResponseBase RestoreCompany(Guid id)
        {
            companyService.Restore(id);
            return new ResponseBase();
        }

        public ResponseBase RestoreFounder(Guid id)
        {
            founderService.Restore(id);
            return new ResponseBase();
        }
    }
}
