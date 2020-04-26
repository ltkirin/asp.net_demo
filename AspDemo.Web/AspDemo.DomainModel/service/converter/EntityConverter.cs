using AspDemo.DomainModel.common.model;
using AspDemo.DomainModel.company.command;
using AspDemo.DomainModel.company.entity;
using AspDemo.DomainModel.company.enums;
using AspDemo.DomainModel.company.model;
using AspDemo.DomainModel.founder.command;
using AspDemo.DomainModel.founder.entity;
using AspDemo.DomainModel.founder.model;
using AspDemo.DomainModel.util;
using System.Collections.Generic;
using System.Linq;

namespace AspDemo.DomainModel.service.converter
{
    public class EntityConverter
    {
        public ListItemModel GetListItemModel(Company company)
        {
            return new ListItemModel() { Value = company.Title, Id = company.Id };
        }

        public ListItemModel GetListItemModel(Founder founder)
        {
            return new ListItemModel() { Value = NamesFormatingHelper.GetDisplayName(founder), Id = founder.Id };
        }

        public CompanyGetModel GetModel(Company company, IList<Founder> founders)
        {
            CompanyGetModel model = new CompanyGetModel()
            {
                Title = company.Title,
                Tin = company.Tin,
                Id = company.Id,
                CompanyType = (int)company.Type
            };
            foreach (Founder founder in founders)
            {
                model.Founders.Add(GetListItemModel(founder));
            }
            return model;
        }

        public FounderGetModel GetModel(Founder founder, IList<Company> companies)
        {
            FounderGetModel model = new FounderGetModel()
            {
                FirstName = founder.FirstName,
                LastName = founder.LastName,
                MiddleName = founder.MiddleName ?? string.Empty,
                Tin = founder.Tin,
                Id = founder.Id
            };
            foreach (Company company in companies)
            {
                model.Companies.Add(GetListItemModel(company));
            }

            return model;
        }

        public FounderDto GetDto(FounderPutModel model)
        {
            return new FounderDto()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName ?? string.Empty,
                Tin = model.Tin,
                RelatedCompaniesIds = model.CompaniesIds.ToArray()
            };
        }

        public FounderDto GetDto(FounderPostModel model)
        {
            return new FounderDto()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName ?? string.Empty,
                Tin = model.Tin
            };
        }

        public CompanyDto GetDto(CompanyPutModel model)
        {
            return new CompanyDto()
            {
                Id = model.Id,
                Tin = model.Tin,
                Title = model.Title,
                CompanyType = (CompanyType)model.CompanyType,
                FoundersIds = model.FoundersIds.ToArray()
            };
        }

        public CompanyDto GetDto(CompanyPostModel model)
        {
            return new CompanyDto()
            {
                Tin = model.Tin,
                Title = model.Title,
                CompanyType = (CompanyType)model.CompanyType,
            };
        }
    }
}
