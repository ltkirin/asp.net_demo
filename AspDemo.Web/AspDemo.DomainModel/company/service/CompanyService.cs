using AspDemo.DomainModel.common.command;
using AspDemo.DomainModel.common.service;
using AspDemo.DomainModel.company.command;
using AspDemo.DomainModel.company.entity;
using AspDemo.DomainModel.context;
using AspDemo.DomainModel.extensions;
using AspDemo.DomainModel.founder.entity;
using AspDemo.DomainModel.founderToCompany.entity;
using AspDemo.DomainModel.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspDemo.DomainModel.company.service
{
    public class CompanyService : ServiceBase, IEntityService<Company>
    {
        public CompanyService(CompanyDbContext context) : base(context)
        {
        }

        public void Create(DtoBase<Company> command)
        {
            CompanyDto dto = command as CompanyDto;
            Company company = new Company();
            UpdateCompanyInfo(company, dto);
            PerformCreate(company);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Company company = GetById<Company>(id);
            PerformDelete(company);
            IEnumerable<FounderToCompany> relations =
                context
                .GetDbSet<FounderToCompany>()
                .Where(r => r.Company == company && !r.IsDeleted);

            foreach (FounderToCompany relation in relations)
            {
                PerformDelete(relation);
            }
            context.SaveChanges();
        }

        public Company FindById(Guid id)
        {
            return GetById<Company>(id);
        }

        public IList<Company> GetAll(bool deleted, int pageNumber, int pageSize)
        {
            return PerformGetAll<Company>(deleted, pageNumber, pageSize);
        }

        public void Restore(Guid id)
        {
            Company company = GetById<Company>(id);
            PerformRestore(company);
            context.SaveChanges();
        }

        public IList<Company> Search(SearchQueryBase<Company> searchQuery)
        {
            CompanySearchQuery query = searchQuery as CompanySearchQuery;
            IQueryable<Company> result;
            if(query.Tin != null)
            {
                result = context
                    .GetDbSet<Company>()
                    .Where(c => c.Tin == query.Tin.Value && !c.IsDeleted);
            }
            else
            {
                if(query.FounderId != null)
                {
                    result = context
                        .GetDbSet<FounderToCompany>()
                        .Where(r => r.Founder.Id == query.FounderId && !r.IsDeleted)
                        .Select(r => r.Company)
                        .Where(c => !c.IsDeleted);
                }
                else
                {
                    result = context
                        .GetDbSet<Company>()
                        .Where(c => !c.IsDeleted);
                }

                if(!string.IsNullOrEmpty(query.Title))
                {
                    result = result.Where(c => c.Title.Contains(query.Title));
                }
                if(query.CompanyType != null)
                {
                    result = result.Where(c => c.Type == query.CompanyType.Value);
                }
            }

            return result
               .Page(searchQuery.PageNumber, searchQuery.PageSize)
               .ToArray();
        }

        public void Update(DtoBase<Company> command)
        {
            CompanyDto dto = command as CompanyDto;
            Company company = GetById<Company>(command.Id.Value);
            UpdateCompanyInfo(company, dto);
            PerformUpdate(company);

            IEnumerable<FounderToCompany> exitingRelations =
                context
                .GetDbSet<FounderToCompany>()
                .Where(r => r.Company == company && !r.IsDeleted);
            foreach (FounderToCompany relation in exitingRelations)
            {
                if (!dto.FoundersIds.Contains(relation.Founder.Id))
                {
                    PerformDelete(relation);
                }
            }
            foreach (Guid founderId in dto.FoundersIds)
            {
                if (!exitingRelations.Any(r => r.Founder.Id == founderId))
                {
                    Founder founder = GetById<Founder>(founderId);
                    PerformCreate(new FounderToCompany() { Founder = founder, Company = company });
                }
            }

            context.SaveChanges();
        }

        private void UpdateCompanyInfo(Company company, CompanyDto dto)
        {
            company.Title = dto.Title;
            company.Tin = dto.Tin;
            company.Type = dto.CompanyType;
        }
    }
}
