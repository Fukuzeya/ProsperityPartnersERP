using ProsperityPartners.Application.Shared.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Shared.CompanyDTOs
{
    public record CompanyDto
    (
        Guid Id, 
        string Name, 
        string Address,
        string Owner,
        IEnumerable<EmployeeDto> Employees
    );
}
