using CompanyEmployees.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Infrastructure.Presentation.Controllers;

[Route("api/companies")]
[ApiController]
public class CompanyController : ControllerBase
{
	private readonly IServiceManager _serviceManager;

	public CompanyController(IServiceManager serviceManager)
	{
		_serviceManager = serviceManager;
	}

	[HttpGet("{id:guid}", Name = "CompanyId")]
	public IActionResult GetCompany()
	{
		var companies = _serviceManager.CompanyService.GetAllCompanies(trackChanges: false);
		return Ok(companies);
	}

	[HttpGet("{id:guid}")]
	public IActionResult GetCompany(Guid id)
	{
		var companies = _serviceManager.CompanyService.GetCompany(id, trackChanges: false);
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
