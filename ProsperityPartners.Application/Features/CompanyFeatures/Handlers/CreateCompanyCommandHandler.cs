using AutoMapper;
using MediatR;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Application.Features.CompanyFeatures.Commands;
using ProsperityPartners.Application.Shared.CompanyDTOs;
using ProsperityPartners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.CompanyFeatures.Handlers
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CompanyDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public CreateCompanyCommandHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<CompanyDto> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = _mapper.Map<Company>(request.CreateCompanyDto);
            await _repositoryManager.Company.CreateCompany(company);
            _repositoryManager.SaveChanges();
            var companyDto = _mapper.Map<CompanyDto>(company);
            return companyDto;
            
        }
    }
}
