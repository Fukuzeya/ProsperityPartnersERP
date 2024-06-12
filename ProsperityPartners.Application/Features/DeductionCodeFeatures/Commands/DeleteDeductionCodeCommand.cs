using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.DeductionCodeFeatures.Commands
{
    public record DeleteDeductionCodeCommand(Guid Id) : IRequest<Unit>;
}
