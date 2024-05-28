using ProsperityPartners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Contracts.Persistance
{
    public interface IRecordRepository : IRepositoryBase<Record>
    {
        Task<IEnumerable<Record>> GetBatchRecordsAsync(Guid batchId, bool trackChanges);
        Task<IEnumerable<Record>> GetCompanyRecordsAsync(Guid companyId, bool trackchanges);
        Task<Record> GetRecordAsync(Guid Id, bool trackChanges);
        Task CreateRecord(Record record);
        void UpdateRecord(Record record);
        void DeleteRecord(Record record);
    }
}
