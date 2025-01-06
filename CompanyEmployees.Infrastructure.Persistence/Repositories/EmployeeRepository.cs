using CompanyEmployees.Core.Domain.Entities;
using CompanyEmployees.Core.Domain.Repositories;

namespace CompanyEmployees.Infrastructure.Persistence.Repositories
{
	public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
	{
		public EmployeeRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{
		}

		public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges)
		{
			var employees = FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
				.OrderBy(e => e.Name)
				.ToList();
			return employees;
		}
	}
}
