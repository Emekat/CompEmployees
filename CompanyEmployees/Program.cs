using CompanyEmployees.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();

// Add services to the container.
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.AddControllers()
	.AddApplicationPart(typeof(CompanyEmployees.Infrastructure.Presentation.AssemblyReference).Assembly);

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}
else
{
	app.UseDeveloperExceptionPage();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
	ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
