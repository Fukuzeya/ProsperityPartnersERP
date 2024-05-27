using Microsoft.EntityFrameworkCore;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Domain.Entities;
using ProsperityPartners.Domain.Exceptions;
using ProsperityPartners.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Persistance.Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) :
            base(repositoryContext) { }

        public async Task CreateCompany(Company company) => await  Create(company);

        public void DeleteCompany(Company company) => Delete(company);
        
        public async Task<IEnumerable<Company>> GetAllCompanies(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Company>> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            return await FindByCondition(c => ids.Contains(c.Id),trackChanges)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<Company?> GetCompany(Guid companyId, bool trackChanges)
        {
            return await FindByCondition(c => c.Id.Equals(companyId), trackChanges)
                .SingleOrDefaultAsync();
        }

        public async Task<Company> GetCompanyAndCheckIfItExists(Guid companyId, bool trackChanges)
        {
            var company = await GetAsync(companyId,trackChanges);
            if(company is null)
                throw new CompanyNotFoundException(companyId);
            return company;

        }
    }
}
