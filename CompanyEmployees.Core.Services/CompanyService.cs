using AutoMapper;
using CompanyEmployees.Core.Domain.Entities;
using CompanyEmployees.Core.Domain.Exceptions;
using CompanyEmployees.Core.Domain.Repositories;
using CompanyEmployees.Core.Services.Abstractions;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Core.Services;

public class CompanyService(IRepositoryManager _repository, IMapper _mapper) : ICompanyService
{
	public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
	{     
        var companies = _repository.Company.GetAllCompanies(trackChanges);
        var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
        return companiesDto;
	}

	public CompanyDto GetCompany(Guid id, bool trackChanges)
	{
		var company = _repository.Company.GetCompany(id, trackChanges);
		if (company is null)
			throw new CompanyNotFoundException(id);

		var companyDto = _mapper.Map<CompanyDto>(company);

		return companyDto;
	}

	public CompanyDto CreateCompany(CompanyForCreationDto company)
	{
		var companyEntity = _mapper.Map<Company>(company);

		_repository.Company.CreateCompany(companyEntity);
		_repository.Save();

		var companyDto = _mapper.Map<CompanyDto>(companyEntity);

		return companyDto;
	}
}
