using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Shared.DeductionCodeDTOs
{
    public abstract record ManipulateDeductionCodeDto
    {
        public required string Code { get; init; }
        public required Guid CompanyId { get; init; }
    }
}
