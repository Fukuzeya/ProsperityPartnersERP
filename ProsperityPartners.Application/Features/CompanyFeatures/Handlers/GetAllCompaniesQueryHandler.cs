using AutoMapper;
using MediatR;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Application.Features.CompanyFeatures.Queries;
using ProsperityPartners.Application.Shared.CompanyDTOs;
using ProsperityPartners.Domain.Contracts;
using ProsperityPartners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.CompanyFeatures.Handlers
{
    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, IEnumerable<CompanyDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        public GetAllCompaniesQueryHandler(IMapper mapper, IRepositoryManager repositoryManager,ILoggerManager loggerManager)
        {
            _loggerManager = loggerManager;
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<IEnumerable<CompanyDto>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await _repositoryManager.Company.GetAllCompanies(trackChanges: false);
            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
        }
    }
}
