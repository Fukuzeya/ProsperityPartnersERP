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
    public class BatchRepository : RepositoryBase<Batch>, IBatchRepository
    {
        public BatchRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task CreateBatchAsync(Batch batch) => await Create(batch);

        public void DeleteBatch(Batch batch) => Delete(batch);
        
        public async Task<IEnumerable<Batch>> GetCompanyBatchesAsync(Guid companyId, bool trackChanges)
        {
            return await FindByCondition(c => c.DeductionCode.CompanyId.Equals(companyId), 
                trackChanges).ToListAsync();
        }

        public async Task<Batch> GetBatchAsync(Guid Id, bool trackChanges)
        {
            var batch =  await GetAsync(Id, trackChanges);
            if (batch is null)
                throw new BatchNotFoundException(Id);
            return batch;
        }

        public void UpdateBatch(Batch batch) => Update(batch);

        public async Task BatchExists(Guid Id) => await Exists(Id);

        public async Task<IEnumerable<Batch>> GetDeductionCodeBatchesAsync(Guid deductionCodeId, bool trackChanges)
        {
            return await FindByCondition(d => d.DeductionCodeId.Equals(deductionCodeId), trackChanges).ToListAsync();
        }
    }
}
