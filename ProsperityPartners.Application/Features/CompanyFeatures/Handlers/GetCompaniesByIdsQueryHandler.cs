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
    public class GetCompaniesByIdsQueryHandler : IRequestHandler<GetCompaniesByIdsQuery,
        IEnumerable<CompanyDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetCompaniesByIdsQueryHandler(IMapper mapper,IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<IEnumerable<CompanyDto>> Handle(GetCompaniesByIdsQuery request, CancellationToken cancellationToken)
        {
            if (request.CompaniesIds is null)
                throw new IdParametersBadRequestException();

            var companiesEntities = await _repositoryManager.Company.GetByIds(request.CompaniesIds,trackChanges:false);
            
            if(request.CompaniesIds.Count() != companiesEntities.Count())
                throw new CollectionByIdsBadRequestException();
            var companiesToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companiesEntities);
            return companiesToReturn;
        }
    }
}
