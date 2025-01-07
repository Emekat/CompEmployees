using CompanyEmployees.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

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

	[HttpGet]
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
}
