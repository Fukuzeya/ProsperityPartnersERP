using ProsperityPartners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Contracts.Persistance
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllCompanies(bool trackChanges);
        Task<Company?> GetCompany(Guid companyId, bool trackChanges);
        Task<IEnumerable<Company>> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        Task<Company> GetCompanyAndCheckIfItExists(Guid companyId, bool trackChanges);
        Task CreateCompany(Company company);
        void DeleteCompany(Company company);
    }
}
