using AutoMapper;
using ProsperityPartners.Application.Shared.AuthenticationaDTOs;
using ProsperityPartners.Application.Shared.BatchDTOs;
using ProsperityPartners.Application.Shared.CompanyDTOs;
using ProsperityPartners.Application.Shared.DeductionCodeDTOs;
using ProsperityPartners.Application.Shared.EmployeeDTOs;
using ProsperityPartners.Application.Shared.RecordDTOs;
using ProsperityPartners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.AutoMapper.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Company mappings
            CreateMap<Company, CompanyDto>();
            CreateMap<CreateCompanyDto, Company>();
            CreateMap<UpdateCompanyDto, Company>();

            // Employee mappings
            CreateMap<Employee, EmployeeDto>();
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();
            
            // Batch mappings
            CreateMap<Batch,BatchDto>();
            CreateMap<CreateBatchDto, Batch>();
            CreateMap<UpdateBatchDto, Batch>();

            // Record mappings
            CreateMap<Record,RecordDto>();
            CreateMap<CreateRecordDto, Record>(); 
            CreateMap<UpdateRecordDto, Record>();

            // DeductionCode mappings
            CreateMap<DeductionCode, DeductionCodeDto>();
            CreateMap<CreateDeductionCodeDto, DeductionCode>();
            CreateMap<UpdateDeductionCodeDto, DeductionCode>();

            // User mappings
            CreateMap<CreateUserDto, User>();
        }
    }
}
