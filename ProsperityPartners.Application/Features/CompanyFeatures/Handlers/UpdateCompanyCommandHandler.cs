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
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public UpdateCompanyCommandHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyEntity = await _repositoryManager.Company.GetCompanyAndCheckIfItExists(request.Id, trackChanges: request.trackChanges);
            _mapper.Map(request.updateCompanyDto,companyEntity);
            _repositoryManager.SaveChanges();
            return Unit.Value;
        }
    }
}
