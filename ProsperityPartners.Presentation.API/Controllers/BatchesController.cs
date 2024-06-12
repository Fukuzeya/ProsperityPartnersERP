using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProsperityPartners.Application.Features.BatchFeatures.Commands;
using ProsperityPartners.Application.Features.BatchFeatures.Queries;
using ProsperityPartners.Application.Features.RecordFeatures.Queries;
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

        [HttpGet("{Id:guid}", Name = "BatchById")]
        public async Task<IActionResult> GetBatch(Guid Id)
        {
            var batch = await _sender.Send(new GetBatchQuery(Id));
            return Ok(batch);
        }

        [HttpGet("{Id:guid}/records")]
        public async Task<IActionResult> GetBatchRecords(Guid Id)
        {
            var records = await _sender.Send(new GetBatchRecordsQuery(Id));
            return Ok(records);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateBatch([FromBody] CreateBatchDto createBatchDto)
        {
            var batch = await _sender.Send(new CreateBatchCommand(createBatchDto));
            return CreatedAtRoute("BatchById", new { BatchId = batch.Id }, batch);
        }

        [HttpPut("{Id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateBatch(Guid Id,[FromBody] UpdateBatchDto updateBatchDto)
        {
            await _sender.Send(new UpdateBatchCommand(Id,updateBatchDto));
            return NoContent();
        }

        [HttpDelete("{Id:guid}")]
        public async Task<IActionResult> DeleteBatch(Guid Id)
        {
            await _sender.Send(new  DeleteBatchCommand(Id));
            return NoContent();
        }
    }
}
