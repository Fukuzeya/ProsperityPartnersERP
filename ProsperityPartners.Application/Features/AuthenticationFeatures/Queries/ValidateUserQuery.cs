using MediatR;
using ProsperityPartners.Application.Shared.AuthenticationaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.AuthenticationFeatures.Queries
{
    public record ValidateUserQuery(UserForAuthenticationDto UserForAuthenticationDto) : IRequest<bool>;
}
