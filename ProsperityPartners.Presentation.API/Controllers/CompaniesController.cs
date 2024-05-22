using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProsperityPartners.Application.Features.CompanyFeatures.Commands;
using ProsperityPartners.Application.Features.CompanyFeatures.Queries;
using ProsperityPartners.Application.Shared.CompanyDTOs;
using ProsperityPartners.Presentation.API.ModelBinders;

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


        [HttpGet("collection/({ids})",Name ="CompanyCollection")]
        public async Task<IActionResult> GetCompanyCollection([ModelBinder(BinderType =
            typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
        {
            var companies = await _sender.Send(new GetCompaniesByIdsQuery(ids));
            return Ok(companies);
            //http://localhost:5041/api/companies/collection/(08dc79fa-4014-4c90-8b41-b7fc5e4ec45d,08dc79fa-4019-4d10-886e-c5997934a3c4) 
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateCompanyCollection([FromBody] IEnumerable<CreateCompanyDto> companyCollection)
        {
            var result = await _sender.Send(new CreateCompanyCollectionCommand(companyCollection));
            return CreatedAtRoute("CompanyCollection", new { result.ids }, result.companies);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            await _sender.Send(new DeleteCompanyCommand(id));
            return NoContent();
        }
    }
}
