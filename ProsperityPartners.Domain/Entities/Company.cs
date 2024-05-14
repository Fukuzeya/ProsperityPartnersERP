using ProsperityPartners.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Domain.Entities
{
    [Table("Companies")]
    public class Company : BaseEntity
    {
        [Column("CompanyId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(60,ErrorMessage = "Maximum length for company name is 60 characters.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Company address is a required field.")]
        public string Address { get; set; } = string.Empty;
        public string Owner { get; set; } = string.Empty;
        public ICollection<DeductionCode>? DeductionCodes { get; set; }
        public ICollection<Employee>? Employees { get; set; }

    }
}
