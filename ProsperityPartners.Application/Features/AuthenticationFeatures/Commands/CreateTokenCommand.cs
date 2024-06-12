using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.AuthenticationFeatures.Commands
{
    public record CreateTokenCommand : IRequest<string>;
}
