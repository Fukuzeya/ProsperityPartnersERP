using AutoMapper;
using MediatR;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Application.Features.EmployeeFeatures.Commands;
using ProsperityPartners.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.EmployeeFeatures.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public UpdateEmployeeCommandHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _repositoryManager.Company.GetCompanyAndCheckIfItExists(request.companyId, false);

            var employeeEntity = await _repositoryManager.Employee.GetEmployee(request.companyId, request.employeeId,true);

            _mapper.Map(request.updateEmployeeDto, employeeEntity);
            _repositoryManager.SaveChanges();
            return Unit.Value;
        }
    }
}
