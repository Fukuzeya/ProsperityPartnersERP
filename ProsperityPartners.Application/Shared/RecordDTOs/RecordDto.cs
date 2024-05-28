using ProsperityPartners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Shared.RecordDTOs
{
    public record RecordDto
    (
        Guid Id,
        string Reference,
        string Idnumber,
        string Ecnumber,
        string Type,
        string Status,
        DateOnly StartDate,
        DateOnly EndDate,
        decimal Amount,
        Guid DeductionCodeId,
        Guid BatchId
    );
}
