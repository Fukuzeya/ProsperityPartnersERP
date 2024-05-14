using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProsperityPartners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Persistance.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData
                (
                    new Employee
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Panashe",
                        LastName = "Mhlanga",
                        Email = "panashe.mhlanga@gmail.com",
                        Phone = "1234567890",
                        Position = "Accountant",
                        CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                    },
                    new Employee
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Nyasha",
                        LastName = "Musongora",
                        Email = "nyasha.musongora@gmail.com",
                        Phone = "1234567890",
                        Position = "Manager",
                        CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                    }

                );
        }
    }
}
