using MediatR;
using ProsperityPartners.Application.Shared.CompanyDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.CompanyFeatures.Queries
{
    public class GetCompanyQuery : IRequest<CompanyDto>
    {
        public Guid CompanyId {  get; set; }
    }
}
