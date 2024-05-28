using AutoMapper;
using MediatR;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Application.Features.EmployeeFeatures.Commands;
using ProsperityPartners.Application.Shared.EmployeeDTOs;
using ProsperityPartners.Domain.Entities;
using ProsperityPartners.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.EmployeeFeatures.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public CreateEmployeeCommandHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _repositoryManager.Company.GetCompanyAndCheckIfItExists(request.companyId, trackChanges: false);

            var employeeEntity =  _mapper.Map<Employee>(request.CreateEmployeeDto);
            await _repositoryManager.Employee.CreateEmployee(request.companyId, employeeEntity);
            _repositoryManager.SaveChanges();

            var employeeDto = _mapper.Map<EmployeeDto>(employeeEntity);
            return employeeDto;
        }
    }
}
