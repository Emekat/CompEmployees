using CompanyEmployees.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Infrastructure.Presentation.Controllers
{
	[Route("api/companies/{companyId}/employees")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IServiceManager _serviceManager;

		public EmployeeController(IServiceManager serviceManager)
		{
			_serviceManager = serviceManager;
		}

		[HttpGet]
		public IActionResult GetEmployeesForCompany(Guid companyId)
		{
			var employees = _serviceManager.EmployeeService.GetEmployees(companyId, trackChanges: false);
			return Ok(employees);
		}
	}
}
