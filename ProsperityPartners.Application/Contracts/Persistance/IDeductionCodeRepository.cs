using ProsperityPartners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Contracts.Persistance
{
    public interface IDeductionCodeRepository : IRepositoryBase<DeductionCode>
    {
        Task<IEnumerable<DeductionCode>> GetCompanyDeductionCodesAsync(Guid companyId, bool trackChanges);
        Task<DeductionCode> GetDeductionCodeAsync(Guid Id, bool trackChanges);
        Task DeductionCodeExists(Guid Id);
        Task CreateDeductionCode(DeductionCode deduction);
        void DeleteDeductionCode(DeductionCode deductionCode);
        void UpdateDeductionCode(DeductionCode deductionCode);
    }
}
