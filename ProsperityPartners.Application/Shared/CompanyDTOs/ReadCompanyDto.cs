using ProsperityPartners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Shared.CompanyDTOs
{
    public record ReadCompanyDto(
        Guid Id, 
        string Name, 
        string Address,
        string Owner,
        List<Employee> Employees
        );
}
