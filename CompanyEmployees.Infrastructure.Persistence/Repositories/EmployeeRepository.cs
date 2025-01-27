﻿using CompanyEmployees.Core.Domain.Entities;
using CompanyEmployees.Core.Domain.Repositories;

namespace CompanyEmployees.Infrastructure.Persistence.Repositories;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
	public EmployeeRepository(RepositoryContext repositoryContext)
		: base(repositoryContext)
	{
	}

	public void CreateEmployeeForCompany(Guid companyId, Employee employee)
	{
		employee.CompanyId = companyId;
		Create(employee);
	}

	public Employee GetEmployee(Guid companyId, Guid id, bool trackChanges)
	{
		var employee = FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id), trackChanges).SingleOrDefault();
		return employee!;
	}


	public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges)
	{
		var employees = FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
			.OrderBy(e => e.Name)
			.ToList();
		return employees;
	}

	public void DeleteEmployee(Company company, Employee employee)
	{
		using var transation = RepositoryContext.Database.BeginTransaction();

		Delete(employee);
		RepositoryContext.SaveChanges();

		if(FindByCondition(e => e.CompanyId == company.Id, false).Any())
		{
			RepositoryContext.Companies!.Remove(company);
			RepositoryContext.SaveChanges();
		}
		transation.Commit();
	}
}
