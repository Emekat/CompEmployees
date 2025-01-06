using LoggingService;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CompanyEmployees;

public class GlobalExceptionHandler(ILoggerManager _logger, IProblemDetailsService _problemDetailsService)  : IExceptionHandler
{
	public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
		CancellationToken cancellationToken)
	{
		httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
		httpContext.Response.ContentType = "application/json";

		_logger.LogError($"Something went wrong: {exception.Message}");

		var problemDetails = new ProblemDetails
		{
			Title = "An error occurred",
			Status = httpContext.Response.StatusCode,
			Detail = exception.Message,
			Type = exception.GetType().Name
		};

		var result = await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext
		{
			HttpContext = httpContext,
			ProblemDetails = problemDetails,
			Exception = exception
		});

		if (!result)
		{
			await httpContext.Response.WriteAsJsonAsync(problemDetails);
		}	
		return true;
	}
}
