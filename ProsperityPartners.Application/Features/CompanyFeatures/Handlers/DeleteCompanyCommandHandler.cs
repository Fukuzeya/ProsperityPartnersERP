using AutoMapper;
using MediatR;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Application.Features.CompanyFeatures.Commands;
using ProsperityPartners.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.CompanyFeatures.Handlers
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public DeleteCompanyCommandHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _repositoryManager.Company.GetCompanyAndCheckIfItExists(request.companyId, trackChanges: false);
            
            _repositoryManager.Company.DeleteCompany(company);
            _repositoryManager.SaveChanges();
            return Unit.Value;
        }
    }
}
