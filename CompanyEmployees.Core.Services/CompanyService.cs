using CompanyEmployees.Core.Domain.Repositories;
using CompanyEmployees.Core.Services.Abstractions;
using LoggingService;
using Shared.DataTransferObjects;

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

		public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
		{
			try
			{
				var companies = _repository.Company.GetAllCompanies(trackChanges);
				var companiesDto = companies.Select(c => new CompanyDto
				(
					c.Id,
					c.Name ?? "",
					string.Join(' ', c.Address, c.Country)
				)).ToList();
				return companiesDto;
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong in the {nameof(GetAllCompanies)}: {ex}");
				throw;
			}
		}
	}
}
