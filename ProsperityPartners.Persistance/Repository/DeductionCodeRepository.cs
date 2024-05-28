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
    public class DeductionCodeRepository : RepositoryBase<DeductionCode>, IDeductionCodeRepository
    {
        public DeductionCodeRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task CreateDeductionCode(DeductionCode deductionCode) => await Create(deductionCode);

        public async Task DeductionCodeExists(Guid Id) => await Exists(Id);

        public void DeleteDeductionCode(DeductionCode deductionCode) => Delete(deductionCode);

        public async Task<IEnumerable<DeductionCode>> GetCompanyDeductionCodesAsync(Guid companyId, bool trackChanges)
        {
            return await FindByCondition(c => c.CompanyId.Equals(companyId), trackChanges).ToListAsync();
        }

        public async Task<DeductionCode> GetDeductionCodeAsync(Guid Id, bool trackChanges)
        {
            var deductionCode = await GetAsync(Id, trackChanges);
            if (deductionCode is null)
                throw new DeductionCodeNotFoundException(Id);

            return deductionCode;
        }

        public void UpdateDeductionCode(DeductionCode deductionCode) => Update(deductionCode);
    }
}
