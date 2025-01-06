using AutoMapper;
using CompanyEmployees.Core.Domain.Repositories;
using CompanyEmployees.Core.Services.Abstractions;

namespace CompanyEmployees.Core.Services;

public class EmployeeService(IRepositoryManager repository, IMapper mapper) : IEmployeeService
{

}
