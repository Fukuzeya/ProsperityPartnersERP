using ProsperityPartners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Contracts.Persistance
{
    public interface IBatchRepository : IRepositoryBase<Batch>
    {
        Task<IEnumerable<Batch>> GetCompanyBatchesAsync(Guid companyId,bool trackChanges);
        Task<IEnumerable<Batch>> GetDeductionCodeBatchesAsync(Guid deductionCodeId, bool trackChanges);
        Task<Batch> GetBatchAsync(Guid Id,bool trackChanges);
        Task BatchExists(Guid Id);
        Task CreateBatchAsync(Batch batch);
        void UpdateBatch(Batch batch);
        void DeleteBatch(Batch batch);
    }
}
