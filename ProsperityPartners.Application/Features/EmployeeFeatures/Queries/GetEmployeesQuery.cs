using MediatR;
using ProsperityPartners.Application.Shared.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.EmployeeFeatures.Queries
{
    public class GetEmployeesQuery : IRequest<IEnumerable<EmployeeDto>>
    {
        public Guid CompanyId { get; set; }
    }
}
