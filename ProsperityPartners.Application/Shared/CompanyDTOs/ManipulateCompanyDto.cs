using ProsperityPartners.Application.Shared.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Shared.CompanyDTOs
{
    public abstract record ManipulateCompanyDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Company name is a required field.")]
        [MaxLength(100, ErrorMessage = "Max length for company name is 100 characters.")]
        public string? Name { get; init; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Company address is a required field.")]
        public string? Address { get; init; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Company owner is a required field.")]
        public string? Owner { get; set; }
    }
}
