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
    public class RecordRepository : RepositoryBase<Record>, IRecordRepository
    {
        public RecordRepository(RepositoryContext repositoryContext) : 
            base(repositoryContext)
        {
        }

        public async Task CreateRecord(Record record) => await Create(record);

        public void DeleteRecord(Record record) => Delete(record);

        public async Task<IEnumerable<Record>> GetBatchRecordsAsync(Guid batchId, bool trackChanges)
        {
            return await FindByCondition(b => b.BatchId.Equals(batchId), trackChanges).ToListAsync();
        }

        public async Task<IEnumerable<Record>> GetCompanyRecordsAsync(Guid companyId, bool trackchanges)
        {
            return await FindByCondition(c => 
                c.Batch.DeductionCode.CompanyId.Equals(companyId), trackchanges)
                .ToListAsync();
        }

        public async Task<Record> GetRecordAsync(Guid Id, bool trackChanges)
        {
            var record = await GetAsync(Id, trackChanges);
            if(record is null)
                throw new RecordNotFoundException(Id);
            return record;
        }

        public void UpdateRecord(Record record) => Update(record);
    }
}
