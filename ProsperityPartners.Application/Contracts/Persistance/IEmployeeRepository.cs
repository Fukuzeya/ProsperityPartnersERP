using ProsperityPartners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Contracts.Persistance
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees(Guid companyId, bool trackChanges);
        Task<Employee?> GetEmployee(Guid companyId, Guid Id, bool trackChanges);
    }
}
