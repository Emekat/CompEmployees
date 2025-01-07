using AutoMapper;
using CompanyEmployees.Core.Domain.Repositories;
using CompanyEmployees.Core.Services.Abstractions;
using LoggingService;

namespace CompanyEmployees.Core.Services
{
	public sealed class ServiceManager : IServiceManager
	{
		private readonly Lazy<IEmployeeService> _employeeService;
		private readonly Lazy<ICompanyService> _companyService;

		public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
		{
			_companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, mapper));
			_employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, mapper));
		}
		public IEmployeeService EmployeeService => _employeeService.Value;
		public ICompanyService CompanyService => _companyService.Value;
	}
}
