using Microsoft.EntityFrameworkCore.Design;
using CompanyEmployees.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployees.ContextFactory;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
{
	private const string AssemblyName = "CompanyEmployees.Infrastructure.Persistence";

	public RepositoryContext CreateDbContext(string[] args)
	{
		var options = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		var builder = new DbContextOptionsBuilder<RepositoryContext>()
			.UseSqlServer(options.GetConnectionString("sqlConnection"),
				  b => b.MigrationsAssembly(AssemblyName));

		return new RepositoryContext(builder.Options);

	}
}
