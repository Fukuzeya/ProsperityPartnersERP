using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Persistance.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ICompanyRepository> _companyRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<IRecordRepository> _recordRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _companyRepository = new Lazy<ICompanyRepository>(() => new
            CompanyRepository(repositoryContext));

            _employeeRepository = new Lazy<IEmployeeRepository>(() => new
            EmployeeRepository(repositoryContext));

            _recordRepository = new Lazy<IRecordRepository>(() => new
            RecordRepository(repositoryContext));
        }


        public ICompanyRepository Company => _companyRepository.Value;

        public IEmployeeRepository Employee => _employeeRepository.Value;

        public IRecordRepository Record => _recordRepository.Value;

        public int SaveChanges() =>  _repositoryContext.SaveChanges();
        
    }
}
