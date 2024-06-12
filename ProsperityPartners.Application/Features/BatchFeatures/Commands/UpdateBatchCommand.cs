using MediatR;
using ProsperityPartners.Application.Shared.BatchDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.BatchFeatures.Commands
{
    public record UpdateBatchCommand(Guid Id, UpdateBatchDto UpdateBatchDto) : IRequest<Unit>;
}
