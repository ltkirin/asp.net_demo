using AspDemo.DomainModel.common.command;
using AspDemo.DomainModel.common.service;
using AspDemo.DomainModel.company.entity;
using AspDemo.DomainModel.context;
using AspDemo.DomainModel.extensions;
using AspDemo.DomainModel.founder.command;
using AspDemo.DomainModel.founder.entity;
using AspDemo.DomainModel.founderToCompany.entity;
using AspDemo.DomainModel.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspDemo.DomainModel.founder.service
{
    public class FounderService : ServiceBase, IEntityService<Founder>
    {
        private const int TinLength = 12;

        public FounderService(CompanyDbContext context) : base(context)
        {
        }

        public void Create(DtoBase<Founder> command)
        {
            FounderDto dto = command as FounderDto;

            Founder founder = new Founder();
            UpdateFounderInfo(founder, dto);
            PerformCreate(founder);
            foreach (Guid id in dto.RelatedCompaniesIds)
            {
                PerformCreate(new FounderToCompany(GetById<Company>(id), founder));
            }
            context.SaveChanges();


        }

        public void Delete(Guid id)
        {
            Founder founder = GetById<Founder>(id);
            PerformDelete(founder);
            IEnumerable<FounderToCompany> relations =
                context
                .GetDbSet<FounderToCompany>()
                .Where(r => r.Founder == founder && !r.IsDeleted);

            foreach (FounderToCompany relation in relations)
            {
                PerformDelete(relation);
            }
            context.SaveChanges();
        }



        public Founder FindById(Guid id)
        {
            return GetById<Founder>(id);
        }

        public new IList<Founder> GetAll(bool deleted, int pageNumber, int pageSize)
        {
            return PerformGetAll<Founder>(deleted, pageNumber, pageSize);
        }

        public void Restore(Guid id)
        {
            Founder founder = GetById<Founder>(id);
            PerformRestore(founder);
            context.SaveChanges();
        }

        public IList<Founder> Search(SearchQueryBase<Founder> searchQuery)
        {
            FounderSerachQuery query = searchQuery as FounderSerachQuery;
            IQueryable<Founder> result;
            if (query.Tin != null)
            {
                result = context
                    .GetDbSet<Founder>()
                    .Where(f => f.Tin == query.Tin.Value);
            }
            else
            {
                if (query.RelatedCompanyId != null)
                {
                    result = context
                        .GetDbSet<FounderToCompany>()
                        .Where(r => r.Company.Id == query.RelatedCompanyId.Value && !r.IsDeleted)
                        .Select(r => r.Founder)
                        .Where(f => !f.IsDeleted);
                }
                else
                {
                    result = context.Founders.Where(f => !f.IsDeleted);
                }

                if (!string.IsNullOrEmpty(query.LastName))
                {
                    result = result.Where(f => f.LastName.Contains(query.LastName));
                }

                if (!string.IsNullOrEmpty(query.FirstName))
                {
                    result = result.Where(f => f.FirstName.Contains(query.FirstName));
                }

                if (!string.IsNullOrEmpty(query.MiddleName))
                {
                    result = result.Where(f => f.MiddleName.Contains(query.MiddleName));
                }

            }

            return result
                .Page(searchQuery.PageNumber, searchQuery.PageSize)
                .ToArray();
        }

        public void Update(DtoBase<Founder> command)
        {
            FounderDto dto = command as FounderDto;

            Founder founder = GetById<Founder>(command.Id.Value);
            UpdateFounderInfo(founder, dto);
            PerformUpdate(founder);

            IEnumerable<FounderToCompany> exitingRelations =
                context
                .GetDbSet<FounderToCompany>()
                .Where(r => r.Founder == founder && !r.IsDeleted && !r.Company.IsDeleted)
                .ToArray();
            foreach (FounderToCompany relation in exitingRelations)
            {
                if (!dto.RelatedCompaniesIds.Contains(relation.CompanyId))
                {
                    PerformDelete(relation);
                }
            }
            foreach (Guid companyId in dto.RelatedCompaniesIds)
            {
                if (!exitingRelations.Any(r => r.CompanyId == companyId))
                {
                    PerformCreate(new FounderToCompany(GetById<Company>(companyId), founder));
                }
            }

            context.SaveChanges();
        }

        private void UpdateFounderInfo(Founder founder, FounderDto dto)
        {
            founder.FirstName = dto.FirstName;
            founder.LastName = dto.LastName;
            founder.MiddleName = dto.MiddleName ?? string.Empty;
            founder.Tin = dto.Tin;
        }

    }
}
