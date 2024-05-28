using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProsperityPartners.Application.Features.BatchFeatures.Commands;
using ProsperityPartners.Application.Features.BatchFeatures.Queries;
using ProsperityPartners.Application.Shared.BatchDTOs;
using ProsperityPartners.Domain.Entities;
using ProsperityPartners.Presentation.API.ActionFilters;

namespace ProsperityPartners.Presentation.API.Controllers
{
    [Route("api/batches")]
    [ApiController]
    public class BatchesController : ControllerBase
    {
        private readonly ISender _sender;
        public BatchesController(ISender sender) => _sender = sender;

        [HttpGet("company/{CompanyId:guid}")]
        public async Task<IActionResult> GetCompanyBatches(Guid CompanyId)
        {
            var batches = await _sender.Send(new GetCompanyBatchesQuery(CompanyId));
            return Ok(batches);
        }

        [HttpGet("{BatchId:guid}",Name = "BatchById")]
        public async Task<IActionResult> GetBatch(Guid BatchId)
        {
            var batch = await _sender.Send(new GetBatchQuery(BatchId));
            return Ok(batch);
        }

        [HttpPost("{DeductionCodeId:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateBatch(Guid DeductionCodeId, CreateBatchDto createBatchDto)
        {
            var batch =  await _sender.Send(new CreateBatchCommand(DeductionCodeId,createBatchDto));
            return CreatedAtRoute("BatchById", new { BatchId = batch.Id }, batch);
        }
    }
}
