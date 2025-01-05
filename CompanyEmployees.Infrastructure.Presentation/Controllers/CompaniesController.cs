﻿using CompanyEmployees.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Infrastructure.Presentation.Controllers
{
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
			try
			{
				var companies = _serviceManager.CompanyService.GetAllCompanies(trackChanges: false);
				return Ok(companies);
			}
			catch
			{
				return StatusCode(500, "Internal server error");
			}
		
		}
	}
}
