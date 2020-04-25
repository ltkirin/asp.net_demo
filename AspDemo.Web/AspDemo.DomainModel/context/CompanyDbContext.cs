﻿using AspDemo.DomainModel.common.entity;
using AspDemo.DomainModel.company.entity;
using AspDemo.DomainModel.founder.entity;
using AspDemo.DomainModel.founderToCompany.entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspDemo.DomainModel.context
{
    public class CompanyDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Founder> Founders { get; set; }
        public DbSet<FounderToCompany> FounderToCompamyRelations { get; set; }

        private IList<object> allSets => new object[] { Companies, Founders, FounderToCompamyRelations };

        public CompanyDbContext(DbContextOptions options) : base(options)
        {

        }

        public CompanyDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseSqlServer(GetConfigString());
        }

        private string GetConfigString()
        {
            string filePath = @"..\\..\\..\\..\\db\\db.mdf";
            return string.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;
            AttachDbFilename={0};
            Integrated Security=True", filePath);
        }

        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : EntityBase
        {
            DbSet<TEntity> set = allSets.FirstOrDefault(s => s is DbSet<TEntity>) as DbSet<TEntity>;
            if(set == null)
            {
                throw new Exception($"DbSet for '{typeof(TEntity).Name}' not found!");
            }
            return set;
        }
    }
}
