﻿using Shared.DataTransferObjects;

namespace CompanyEmployees.Core.Services.Abstractions;

public interface IEmployeeService
{
	IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges);
	EmployeeDto GetEmployee(Guid companyId, Guid id, bool trackChanges);
	EmployeeDto CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto employeeForCreation,
	   bool trackChanges);
	void DeleteEmployeeForCompany(Guid companyId, Guid id, bool trackChanges);
}
