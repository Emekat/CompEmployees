using CompanyEmployees.Core.Services.Abstractions;
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
}
