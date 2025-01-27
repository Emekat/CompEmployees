﻿using CompanyEmployees.Core.Services.Abstractions;
using CompanyEmployees.Infrastructure.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Infrastructure.Presentation.Controllers;

[Route("api/companies")]
[ApiController]
public class CompaniesController : ControllerBase
{
	private readonly IServiceManager _serviceManager;

	public CompaniesController(IServiceManager serviceManager)
	{
		_serviceManager = serviceManager;
	}

	[HttpGet]
	public IActionResult GetCompanies()
	{
		var companies = _serviceManager.CompanyService.GetAllCompanies(trackChanges: false);
		return Ok(companies);
	}

	[HttpGet("{id:guid}", Name = "CompanyById")]
	public IActionResult GetCompany(Guid companyId)
	{
		var companies = _serviceManager.CompanyService.GetCompany(companyId, trackChanges: false);
		return Ok(companies);
	}

	[HttpPost]
	public IActionResult CreateCompany([FromBody] CompanyForCreationDto company)
	{
		if (company is null)
			return BadRequest("CompanyForCreationDto object is null");

		var createdCompany = _serviceManager.CompanyService.CreateCompany(company);

		return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
	}

	[HttpGet("collection/({ids})", Name = "CompanyCollection")]
	public IActionResult GetCompanyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] 
	IEnumerable<Guid> ids)
	{
		var companies = _serviceManager.CompanyService.GetByIds(ids, trackChanges: false);
		return Ok(companies);
	}

	[HttpPost("collection")]
	public IActionResult CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
	{
		var result = _serviceManager.CompanyService.CreateCompanyCollection(companyCollection);
		return CreatedAtRoute("CompanyCollection", new { result.ids }, result.companies);
	}

	[HttpDelete("{id:guid}")]
	public IActionResult DeleteEmployeeForCompany(Guid companyId, Guid id)
	{
		_serviceManager.EmployeeService.DeleteEmployeeForCompany(companyId, id, trackChanges: false);
		return NoContent();
	}
}
