using MediatR;
using ProsperityPartners.Application.Shared.CompanyDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.CompanyFeatures.Commands
{
    public class CreateCompanyCommand : IRequest<CompanyDto>
    {
        public CreateCompanyDto? CreateCompanyDto { get; set; }
    }
}
