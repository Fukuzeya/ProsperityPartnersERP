using Microsoft.EntityFrameworkCore;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Domain.Entities;
using ProsperityPartners.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Persistance.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : 
            base(repositoryContext)
        {
        }

        public async Task<Employee?> GetEmployee(Guid companyId, Guid Id, bool trackChanges)
        {
            return await FindByCondition(emp => emp.CompanyId.Equals(companyId)
                && emp.Id.Equals(Id),trackChanges).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployees(Guid companyId, bool trackChanges)
        {
            return await FindByCondition(e => e.CompanyId.Equals(companyId),trackChanges)
                .OrderBy(e => e.LastName)
                .ToListAsync();
        }
    }
}
