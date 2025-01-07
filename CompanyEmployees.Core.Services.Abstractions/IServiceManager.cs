namespace CompanyEmployees.Core.Services.Abstractions;

public interface IServiceManager
{
	IEmployeeService EmployeeService { get; }
	ICompanyService CompanyService { get; }
}