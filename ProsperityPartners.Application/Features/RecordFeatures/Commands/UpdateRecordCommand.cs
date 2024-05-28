using MediatR;
using ProsperityPartners.Application.Shared.RecordDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.RecordFeatures.Commands
{
    public record UpdateRecordCommand(UpdateRecordDto UpdateRecordDto) : IRequest<Unit>;
}
