using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProsperityPartners.Application.Features.CompanyFeatures.Commands;
using ProsperityPartners.Application.Features.CompanyFeatures.Queries;
using ProsperityPartners.Application.Shared.CompanyDTOs;

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
            //throw new Exception("Exception");
            var result = await _sender.Send(new GetAllCompaniesQuery());
            return Ok(result);
        }

        [HttpGet("{Id:guid}", Name = "CompanyById")]
        public async Task<IActionResult> GetCompany(Guid Id)
        {
            var company = await _sender.Send(new GetCompanyQuery()
            {
                CompanyId = Id
            });

            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyDto createCompanyDto)
        {
            if (createCompanyDto is null)
                return BadRequest("Company Dto is null");

            var company = await _sender.Send(new CreateCompanyCommand()
            {
                CreateCompanyDto = createCompanyDto
            });
            return CreatedAtRoute("CompanyById", new {id = company.Id},company);
        }
    }
}
