using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.EmployeeFeatures.Commands
{
    public record DeleteEmployeeCommand(Guid companyId, Guid employeeId) : IRequest<Unit>;
}
