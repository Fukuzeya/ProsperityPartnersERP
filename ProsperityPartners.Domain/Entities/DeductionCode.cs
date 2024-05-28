using ProsperityPartners.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace ProsperityPartners.Domain.Entities
{
    public class DeductionCode : BaseEntity
    {
        [Column("DeductionCodeId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Deduction code is a required field.")]
        public string Code { get; set; } = string.Empty;

        [ForeignKey(nameof(Company))]
        public Guid CompanyId {  get; set; }
        public Company? Company { get; set; }
        public ICollection<Record>? Records { get; set; }

    }
}