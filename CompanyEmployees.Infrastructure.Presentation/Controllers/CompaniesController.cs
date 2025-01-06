using CompanyEmployees.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

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

	[HttpGet("{id:Guid}")]
	public IActionResult GetCompanies(Guid id)
	{
		var companies = _serviceManager.CompanyService.GetCompany(id, trackChanges: false);
		return Ok(companies);
	}
}
