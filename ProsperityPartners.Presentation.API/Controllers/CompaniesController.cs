using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ProsperityPartners.Application.Features.BatchFeatures.Queries;
using ProsperityPartners.Application.Features.CompanyFeatures.Commands;
using ProsperityPartners.Application.Features.CompanyFeatures.Queries;
using ProsperityPartners.Application.Features.DeductionCodeFeatures.Queries;
using ProsperityPartners.Application.Features.RecordFeatures.Queries;
using ProsperityPartners.Application.Shared.CompanyDTOs;
using ProsperityPartners.Presentation.API.ActionFilters;
using ProsperityPartners.Presentation.API.ModelBinders;

namespace ProsperityPartners.Presentation.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}/companies")]
    //[ResponseCache(CacheProfileName = "120SecondsDuration")]
    [OutputCache(PolicyName = "120SecondsDuration")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ISender _sender;

        public CompaniesController(ISender sender) => _sender = sender;

        [HttpGet]
        //[ResponseCache(Duration = 60)]
        public async Task<IActionResult> GetAllCompanies()
        {
            //throw new Exception("Exception");
            var result = await _sender.Send(new GetAllCompaniesQuery());
            return Ok(result);
        }

        [HttpGet("{Id:guid}/deductionCodes")]
        public async Task<IActionResult> GetCompanyDeductionCodes(Guid Id)
        {
            var deductionCodes = await _sender.Send(new GetCompanyDeductionCodesQuery(Id));
            return Ok(deductionCodes);
        }

        [HttpGet("{Id:guid}/batches")]
        public async Task<IActionResult> GetCompanyBatches(Guid Id)
        {
            var batches = await _sender.Send(new GetCompanyBatchesQuery(Id));
            return Ok(batches);
        }

        [HttpGet("{Id:guid}/records")]
        public async Task<IActionResult> GetCompanyRecords(Guid Id)
        {
            var records = await _sender.Send(new GetCompanyRecordsQuery(Id));
            return Ok(records);
        }

        [HttpGet("{Id:guid}", Name = "CompanyById")]
        //[ResponseCache(Duration = 60)]
        [OutputCache(Duration = 60)]
        public async Task<IActionResult> GetCompany(Guid Id)
        {
            var company = await _sender.Send(new GetCompanyQuery()
            {
                CompanyId = Id
            });

            return Ok(company);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [OutputCache(NoStore = true)]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyDto createCompanyDto)
        {
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
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCompanyCollection([FromBody] IEnumerable<CreateCompanyDto> companyCollection)
        {
            var result = await _sender.Send(new CreateCompanyCollectionCommand(companyCollection));
            return CreatedAtRoute("CompanyCollection", new { result.ids }, result.companies);
        }

        [HttpDelete("{id:guid}")]
        [OutputCache(NoStore = true)]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            await _sender.Send(new DeleteCompanyCommand(id));
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] UpdateCompanyDto updateCompanyDto)
        {
            await _sender.Send(new UpdateCompanyCommand(id, updateCompanyDto,trackChanges:true));
            return NoContent();
        }
    }
}
