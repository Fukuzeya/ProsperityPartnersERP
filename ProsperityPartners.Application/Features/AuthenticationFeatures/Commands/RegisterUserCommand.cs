using MediatR;
using Microsoft.AspNetCore.Identity;
using ProsperityPartners.Application.Shared.AuthenticationaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.AuthenticationFeatures.Commands
{
    public record RegisterUserCommand(CreateUserDto CreateUserDto) : IRequest<IdentityResult>;
}
