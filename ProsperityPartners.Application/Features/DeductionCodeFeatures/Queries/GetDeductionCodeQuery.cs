using MediatR;
using ProsperityPartners.Application.Shared.DeductionCodeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.DeductionCodeFeatures.Queries
{
    public record GetDeductionCodeQuery(Guid Id) : IRequest<DeductionCodeDto>;
}
