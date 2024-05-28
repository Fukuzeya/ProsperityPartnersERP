using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Shared.RecordDTOs
{
    public abstract record ManipulateRecordDto
    {
        public required string Reference { get; init; }
        public required string Idnumber { get; init; }
        public required string Ecnumber { get; init; }
        public required string Type { get; init; }
        public required string Status { get; init; }
        public required DateOnly StartDate { get; init; }
        public required DateOnly EndDate { get; init; }
        public required decimal Amount { get; init; }
        public required Guid DeductionCodeId { get; init; }
        public required Guid BatchId { get; init; }
    }
}
