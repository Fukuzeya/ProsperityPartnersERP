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
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public DeleteEmployeeCommandHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _repositoryManager.Company.GetCompanyAndCheckIfItExists(request.companyId,trackChanges: false);

            var employeeEntity = await _repositoryManager.Employee.GetEmployee(request.companyId, request.employeeId, true);


            _repositoryManager.Employee.DeleteEmployee(employeeEntity);
            _repositoryManager.SaveChanges();
            return Unit.Value;
        }
    }
}
