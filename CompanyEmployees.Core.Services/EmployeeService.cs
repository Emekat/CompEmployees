using AutoMapper;
using CompanyEmployees.Core.Domain.Exceptions;
using CompanyEmployees.Core.Domain.Repositories;
using CompanyEmployees.Core.Services.Abstractions;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Core.Services;

public class EmployeeService(IRepositoryManager repository, IMapper mapper) : IEmployeeService
{
	public EmployeeDto GetEmployee(Guid companyId, Guid id, bool trackChanges)
	{
		var company = repository.Company.GetCompany(companyId, trackChanges);
		if (company is null)
			throw new CompanyNotFoundException(companyId);

		var employee = repository.Employee.GetEmployee(companyId, id, trackChanges);
		if (employee is null)
			throw new EmployeeNotFoundException(id);
		var employeeDto = mapper.Map<EmployeeDto>(employee);
		return employeeDto;
	}

	public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges)
	{
		var company = repository.Company.GetCompany(companyId, trackChanges);
		if (company is null)
			throw new CompanyNotFoundException(companyId);

		var employees = repository.Employee.GetEmployees(companyId, trackChanges);
		var employeesDto = mapper.Map<IEnumerable<EmployeeDto>>(employees);

		return employeesDto;
	}
}
