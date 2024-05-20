using ProsperityPartners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Shared.EmployeeDTOs
{
    public record EmployeeDto(Guid Id,string FirstName,string lastName,
        string Email,string Phone,string Position);
}
