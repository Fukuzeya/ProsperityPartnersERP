using MediatR;
using ProsperityPartners.Application.Shared.DeductionCodeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.DeductionCodeFeatures.Commands
{
    public record CreateDeductionCodeCommand
        (
            Guid companyId, 
            CreateDeductionCodeDto CreateDeductionCodeDto
        ) : IRequest<DeductionCodeDto>;
}
