using ProsperityPartners.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Persistance.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        public ICompanyRepository CompanyRepository => throw new NotImplementedException();

        public IEmployeeRepository EmployeeRepository => throw new NotImplementedException();

        public IRecordRepository RecordRepository => throw new NotImplementedException();

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
