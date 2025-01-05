using CompanyEmployees.Core.Domain.Entities;
using CompanyEmployees.Core.Domain.Repositories;
using CompanyEmployees.Core.Services.Abstractions;
using LoggingService;
using Microsoft.Extensions.Logging;

namespace CompanyEmployees.Core.Services
{
	public class CompanyService : ICompanyService
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;

		public CompanyService(IRepositoryManager repository, ILoggerManager logger)
		{
			_repository = repository;
			_logger = logger;
		}

		public IEnumerable<Company> GetAllCompanies(bool trackChanges)
		{
			try
			{
				var companies = _repository.Company.GetAllCompanies(trackChanges);
				return companies;
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong in the {nameof(GetAllCompanies)}: {ex}");
				throw;
			}
		}
	}
}
