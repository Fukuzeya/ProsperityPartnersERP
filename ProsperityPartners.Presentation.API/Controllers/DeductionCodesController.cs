using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProsperityPartners.Application.Features.BatchFeatures.Queries;
using ProsperityPartners.Application.Features.DeductionCodeFeatures.Commands;
using ProsperityPartners.Application.Features.DeductionCodeFeatures.Queries;
using ProsperityPartners.Application.Shared.DeductionCodeDTOs;
using ProsperityPartners.Domain.Entities;
using ProsperityPartners.Presentation.API.ActionFilters;

namespace ProsperityPartners.Presentation.API.Controllers
{
    [Route("api/deductionCodes")]
    [ApiController]
    public class DeductionCodesController : ControllerBase
    {
        private readonly ISender _sender;
        public DeductionCodesController(ISender sender) => _sender = sender;

        [HttpGet("{Id:guid}",Name = "DeductionCodeById")]
        public async Task<IActionResult> GetDeductionCode(Guid Id)
        {
            var deductionCode = await _sender.Send(new GetDeductionCodeQuery(Id));
            return Ok(deductionCode);
        }

        [HttpGet("{Id:guid}/batches")]
        public async Task<IActionResult> GetDeductionCodeBatches(Guid Id)
        {
            var batches = await _sender.Send(new GetDeductionCodeBatchesQuery(Id));
            return Ok(batches);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateDeductionCode([FromBody] CreateDeductionCodeDto createDeductionCodeDto)
        {
            var deductionCode = await _sender.Send(new CreateDeductionCodeCommand(createDeductionCodeDto));
            return CreatedAtRoute("DeductionCodeById", new { Id = deductionCode.Id }, deductionCode);
        }

        [HttpPut("{Id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateDeductionCode(Guid Id, UpdateDeductionCodeDto updateDeductionCodeDto)
        {
            await _sender.Send(new UpdateDeductionCodeCommand(Id, updateDeductionCodeDto));
            return NoContent();
        }

        [HttpDelete("{Id:guid}")]
        public async Task<IActionResult> DeleteDeductionCode(Guid Id)
        {
            await _sender.Send(new DeleteDeductionCodeCommand(Id));
            return NoContent();
        }


    }
}
