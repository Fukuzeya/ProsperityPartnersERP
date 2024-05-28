using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Shared.BatchDTOs
{
    public record BatchDto
    (
        Guid Id,
        string Status,
        string Paymaster,
        DateOnly DateSent,
        Guid DeductionCodeId
    );
}
