using AutoMapper;
using MediatR;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Application.Features.CompanyFeatures.Queries;
using ProsperityPartners.Application.Shared.CompanyDTOs;
using ProsperityPartners.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.CompanyFeatures.Handlers
{
    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, CompanyDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
        public GetCompanyQueryHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<CompanyDto> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            var company = await _repositoryManager.Company.GetCompanyAndCheckIfItExists(request.CompanyId, trackChanges: false);
            var companyDto = _mapper.Map<CompanyDto>(company);
            return companyDto;
        }
    }
}
