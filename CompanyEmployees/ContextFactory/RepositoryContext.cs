using Microsoft.EntityFrameworkCore.Design;
using CompanyEmployees.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployees.ContextFactory
{
	public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
	{
		public RepositoryContext CreateDbContext(string[] args)
		{
			var options = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			var builder = new DbContextOptionsBuilder<RepositoryContext>()
				.UseSqlServer(options.GetConnectionString("sqlConnection"),
					  b => b.MigrationsAssembly("CompanyEmployees.Infrastructure.Persistence"));

			return new RepositoryContext(builder.Options);

		}
	}
}
