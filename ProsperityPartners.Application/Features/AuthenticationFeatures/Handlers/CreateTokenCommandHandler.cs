using MediatR;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Application.Features.AuthenticationFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.AuthenticationFeatures.Handlers
{
    public class CreateTokenCommandHandler : IRequestHandler<CreateTokenCommand, string>
    {
        private readonly IRepositoryManager _repositoryManager;
        public CreateTokenCommandHandler(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
        public async Task<string> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            var token = await _repositoryManager.Authentication.CreateToken();
            return token;
        }
    }
}
