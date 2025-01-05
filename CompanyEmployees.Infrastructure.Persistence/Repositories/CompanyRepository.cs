using CompanyEmployees.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.Infrastructure.Persistence.Repositories
{
	public class CompanyRepository : RepositoryBase<Company>
	{
		public CompanyRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{
		}
	}
}
