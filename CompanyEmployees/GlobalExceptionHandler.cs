using Microsoft.AspNetCore.Diagnostics;

namespace CompanyEmployees;

public class GlobalExceptionHandler : IExceptionHandler
{
	public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
		CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}
