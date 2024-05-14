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
    public class DeductionCodeConfiguration : IEntityTypeConfiguration<DeductionCode>
    {
        public void Configure(EntityTypeBuilder<DeductionCode> builder)
        {
            builder.HasData
                (
                    new DeductionCode
                    {
                        Id = Guid.NewGuid(),
                        Code = "254576666323587",
                        CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                    }
                );
        }
    }
}
