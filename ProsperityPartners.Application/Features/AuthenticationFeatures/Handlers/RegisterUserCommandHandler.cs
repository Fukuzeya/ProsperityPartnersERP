using MediatR;
using Microsoft.AspNetCore.Identity;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Application.Features.AuthenticationFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.AuthenticationFeatures.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, IdentityResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        public RegisterUserCommandHandler(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
        public async Task<IdentityResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            await _repositoryManager.Company.GetCompanyAndCheckIfItExists(request.CreateUserDto.CompanyId, trackChanges: false);
            var result = await _repositoryManager.Authentication.RegisterUser(request.CreateUserDto);
            return result;
        }
    }
}
