using MediatR;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Application.Features.AuthenticationFeatures.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.AuthenticationFeatures.Handlers
{
    public class ValidateUserQueryHandler : IRequestHandler<ValidateUserQuery, bool>
    {
        private readonly IRepositoryManager _repositoryManager;
        public ValidateUserQueryHandler(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
        public async Task<bool> Handle(ValidateUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _repositoryManager.Authentication.ValidateUser(request.UserForAuthenticationDto);
            return result;
        }
    }
}
