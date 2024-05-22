using AutoMapper;
using MediatR;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Application.Features.CompanyFeatures.Commands;
using ProsperityPartners.Application.Shared.CompanyDTOs;
using ProsperityPartners.Domain.Entities;
using ProsperityPartners.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.CompanyFeatures.Handlers
{
    public class CreateCompanyCollectionCommandHandler : IRequestHandler<CreateCompanyCollectionCommand, (IEnumerable<CompanyDto> companies, string ids)>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public CreateCompanyCollectionCommandHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<(IEnumerable<CompanyDto> companies, string ids)> Handle(CreateCompanyCollectionCommand request, CancellationToken cancellationToken)
        {
            if (request.CompanyCollection is null)
                throw new CompanyCollectionBadRequest();

            var companiesEntity = _mapper.Map<IEnumerable<Company>>(request.CompanyCollection);
            foreach(var company in companiesEntity)
            {
                await _repositoryManager.Company.CreateCompany(company);
            }
            _repositoryManager.SaveChanges();

            var companiesCollectionToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companiesEntity);
            var ids = string.Join(",", companiesCollectionToReturn.Select(c => c.Id));

            return (companiesCollectionToReturn, ids);
        }
    }
}
