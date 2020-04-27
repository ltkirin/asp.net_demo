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

        public FounderFullModel GetFullModel(Founder founder, IList<Company> companies)
        {
            return new FounderFullModel()
            {
                Id = founder.Id,
                FirstName = founder.FirstName,
                LastName = founder.LastName,
                MiddleName = founder.MiddleName ?? string.Empty,
                Tin = founder.Tin,
                CompaniesIds = companies.Select(c => c.Id).ToList()
            };
        }

        public CompanyFullModel GetFullModel(Company company, IList<Founder> founders)
        {
            return new CompanyFullModel()
            {
                Id = company.Id,
                Title = company.Title,
                Tin = company.Tin,
                CompanyType = (int)company.Type,
                FoundersIds = founders.Select(c => c.Id).ToList()
            };
        }

        public FounderDto GetDto(FounderFullModel model)
        {
            return new FounderDto()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName ?? string.Empty,
                Tin = model.Tin,
                RelatedCompaniesIds = model.CompaniesIds
            };
        }

        public CompanyDto GetDto(CompanyFullModel model)
        {
            return new CompanyDto()
            {
                Id = model.Id,
                Tin = model.Tin,
                Title = model.Title,
                CompanyType = (CompanyType)model.CompanyType,
                FoundersIds = model.FoundersIds
            };
        }

    }
}
