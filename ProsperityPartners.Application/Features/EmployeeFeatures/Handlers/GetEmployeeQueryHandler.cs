using AutoMapper;
using MediatR;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Application.Features.EmployeeFeatures.Queries;
using ProsperityPartners.Application.Shared.EmployeeDTOs;
using ProsperityPartners.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.EmployeeFeatures.Handlers
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, EmployeeDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetEmployeeQueryHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<EmployeeDto> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var company = await _repositoryManager.Company.GetCompany(request.CompanyId, trackChanges: false);

            if (company is null)
                throw new CompanyNotFoundException(request.CompanyId);

            var employee = await _repositoryManager.Employee.GetEmployee(request.CompanyId,
                request.EmployeeId,trackChanges: false);

            if(employee is null)
                throw new EmployeeNotFoundException(request.EmployeeId);

            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }
    }
}
