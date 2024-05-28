using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Contracts.Persistance
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }
        IRecordRepository Record { get; }
        IBatchRepository Batch { get; }
        IDeductionCodeRepository DeductionCode { get; }
        int SaveChanges();
    }
}
