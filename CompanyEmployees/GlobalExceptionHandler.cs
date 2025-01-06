using LoggingService;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CompanyEmployees;

public class GlobalExceptionHandler(ILoggerManager _logger)  : IExceptionHandler
{
	public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
		CancellationToken cancellationToken)
	{
		httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
		httpContext.Response.ContentType = "application/json";

		_logger.LogError($"Something went wrong: {exception.Message}");

		await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
		{
			Title = "An error occurred",
			Status = httpContext.Response.StatusCode,
			Detail = exception.Message,
			Type = exception.GetType().Name
		});
		return true;
	}
}
