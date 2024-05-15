using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProsperityPartners.Application.Features.CompanyFeatures.Queries;

namespace ProsperityPartners.Presentation.API.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ISender _sender;

        public CompaniesController(ISender sender) => _sender = sender;

        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            throw new Exception("Exception");
            var result = await _sender.Send(new GetAllCompaniesQuery());
            return Ok(result);
        }
    }
}
