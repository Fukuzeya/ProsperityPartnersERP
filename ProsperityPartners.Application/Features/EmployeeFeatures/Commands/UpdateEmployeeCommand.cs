using MediatR;
using ProsperityPartners.Application.Shared.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.EmployeeFeatures.Commands
{
    public record UpdateEmployeeCommand
    (
        Guid companyId,
        Guid employeeId,
        UpdateEmployeeDto updateEmployeeDto
    ) : IRequest<Unit>;
}
