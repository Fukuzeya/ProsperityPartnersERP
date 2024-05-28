using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Shared.BatchDTOs
{
    public abstract record ManipulateBatchDto
    {
        [Required(AllowEmptyStrings = false,ErrorMessage ="Batch status is a required field.")]
        public required string Status {  get; init; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Paymaster is a required field.")]
        public required string Paymaster {  get; init; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "DeductionCode is a required field.")]
        public required Guid DeductionCodeId { get; init; }
    }
}
