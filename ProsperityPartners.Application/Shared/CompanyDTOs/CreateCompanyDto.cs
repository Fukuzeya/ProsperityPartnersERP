﻿using ProsperityPartners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProsperityPartners.Application.Shared.EmployeeDTOs;

namespace ProsperityPartners.Application.Shared.CompanyDTOs
{
    public record CreateCompanyDto : ManipulateCompanyDto;

}
