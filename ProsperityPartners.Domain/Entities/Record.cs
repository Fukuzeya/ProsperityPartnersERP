using ProsperityPartners.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Domain.Entities
{
    public class Record : BaseEntity
    {
        public Guid Id { get; set; }
        public string Reference { get; set; } = string.Empty;
        public string Idnumber { get; set; } = string.Empty;
        public string Ecnumber { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set;}
        public decimal Amount { get; set; }
        [ForeignKey(nameof(DeductionCode))]
        public Guid DeductionCodeId { get; set; }
        public DeductionCode? DeductionCode { get; set; }
        [ForeignKey(nameof(Batch))]
        public Guid BatchId { get; set;}
        public Batch? Batch { get; set; }

    }
}
