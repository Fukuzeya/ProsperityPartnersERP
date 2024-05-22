using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Shared.EmployeeDTOs
{
    public record UpdateEmployeeDto
    (
        string FirstName,
        string lastName,
        string Email,
        string Phone,
        string Position
    );
}
