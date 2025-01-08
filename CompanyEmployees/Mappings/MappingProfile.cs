﻿using AutoMapper;
using CompanyEmployees.Core.Domain.Entities;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Mappings;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Company, CompanyDto>()
			.ForMember(c => c.FullAddress,
			   opt => opt.MapFrom(x => $"{x.Address}  {x.Country}"));

		CreateMap<Employee, EmployeeDto>();

		CreateMap<CompanyForCreationDto, Company>();
	}
}
