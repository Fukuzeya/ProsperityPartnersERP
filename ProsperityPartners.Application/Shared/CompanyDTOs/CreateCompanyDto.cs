using ProsperityPartners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Shared.CompanyDTOs
{
    public class CreateCompanyDto
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string Owner { get; set; }
    }

}
