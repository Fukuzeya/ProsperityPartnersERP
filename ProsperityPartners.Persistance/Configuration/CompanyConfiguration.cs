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
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData
                (
                    new Company
                    {
                        Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                        Name = "Prosperity Partners",
                        Owner = "Sam Fukuzeya",
                        Address = "123 Main Street Mutare, Zimbabwe"
                    },
                    new Company
                    {
                        Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                        Name = "Twilight Tech World",
                        Owner = "Brian Masase",
                        Address = "123 Downtown Mutare, Zimbabwe"
                    }

                );
        }
    }
}
