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
            await _repositoryManager.Company.GetCompanyAndCheckIfItExists(request.CompanyId, trackChanges: false);

            var employee = await _repositoryManager.Employee.GetEmployee(request.CompanyId,
                request.EmployeeId,trackChanges: false);

            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }
    }
}
