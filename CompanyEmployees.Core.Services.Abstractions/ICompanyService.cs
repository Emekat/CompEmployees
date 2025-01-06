using Shared.DataTransferObjects;

namespace CompanyEmployees.Core.Services.Abstractions
{
	public interface ICompanyService
	{
		IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);
		CompanyDto? GetCompany(Guid id, bool trackChanges);
	}
}
