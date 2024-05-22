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
            var company = await _repositoryManager.Company.GetCompany(request.companyId,trackChanges: false);
            if (company is null)
                throw new CompanyNotFoundException(request.companyId);

            var employeeForCompany = await _repositoryManager.Employee.GetEmployee(request.companyId, request.employeeId,trackChanges:false);
            if (employeeForCompany is null)
                throw new EmployeeNotFoundException(request.employeeId);

            _repositoryManager.Employee.DeleteEmployee(employeeForCompany);
            _repositoryManager.SaveChanges();
            return Unit.Value;
        }
    }
}
