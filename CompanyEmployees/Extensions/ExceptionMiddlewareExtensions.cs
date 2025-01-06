﻿using LoggingService;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CompanyEmployees.Extensions;

public static class ExceptionMiddlewareExtensions
{
	public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager logger)
	{
		app.UseExceptionHandler(appError =>
		{
			appError.Run(async context =>
			{
				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				context.Response.ContentType = "application/json";

				var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
				if (contextFeature != null)
				{
					logger.LogError($"Something went wrong: {contextFeature.Error}");

					await context.Response.WriteAsJsonAsync(new ProblemDetails
					{
						Title = "An error occurred",
						Status = context.Response.StatusCode,
						Detail = contextFeature.Error.Message,
						Type = contextFeature.Error.GetType().Name
					});
				}
			});
		});
	}
}
