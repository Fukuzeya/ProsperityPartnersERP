﻿using Microsoft.EntityFrameworkCore;
using ProsperityPartners.Domain.Entities;
using ProsperityPartners.Persistance.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Persistance.Context
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new DeductionCodeConfiguration());
        }

        public DbSet<Batch> Batches { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<DeductionCode> DeductionCodes { get; set;}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Record> Records { get; set; }
    }
}