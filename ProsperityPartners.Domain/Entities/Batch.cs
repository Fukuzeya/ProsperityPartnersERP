using ProsperityPartners.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Domain.Entities
{
    [Table("Batches")]
    public class Batch : BaseEntity
    {
        [Column("BatchId")]
        public Guid Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Paymaster { get; set; } = string.Empty;
        public DateOnly DateSent { get; set; }
        [ForeignKey(nameof(DeductionCode))]
        public Guid DeductionCodeId { get; set; }
        public DeductionCode? DeductionCode { get; set; }

    }
}
