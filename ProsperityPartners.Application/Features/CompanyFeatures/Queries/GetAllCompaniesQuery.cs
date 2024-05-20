using MediatR;
using ProsperityPartners.Application.Shared.CompanyDTOs;

namespace ProsperityPartners.Application.Features.CompanyFeatures.Queries
{
    public class GetAllCompaniesQuery : IRequest<IEnumerable<CompanyDto>>
    {

    }
}
