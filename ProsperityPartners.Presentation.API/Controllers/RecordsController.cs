using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProsperityPartners.Application.Features.RecordFeatures.Commands;
using ProsperityPartners.Application.Features.RecordFeatures.Queries;
using ProsperityPartners.Application.Shared.RecordDTOs;
using ProsperityPartners.Presentation.API.ActionFilters;

namespace ProsperityPartners.Presentation.API.Controllers
{
    [Route("api/records")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly ISender _sender;
        public RecordsController(ISender sender) => _sender = sender;

        [HttpGet("{Id:guid}",Name = "GetRecordById")]
        public async Task<IActionResult> GetRecord(Guid Id)
        {
            var record = await _sender.Send(new GetRecordQuery(Id));
            return Ok(record);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateRecord([FromBody] CreateRecordDto createRecordDto)
        {
            var result = await _sender.Send(new CreateRecordCommand(createRecordDto));
            return CreatedAtRoute("GetRecordById", new { Id = result.Id }, result);
        }

        [HttpPut("{Id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateRecord(Guid Id, [FromBody] UpdateRecordDto updateRecordDto)
        {
            await _sender.Send(new UpdateRecordCommand(updateRecordDto));
            return NoContent();
        }

        [HttpDelete("{Id:guid}")]
        public async Task<IActionResult> DeleteRecord(Guid Id)
        {
            await _sender.Send(new DeleteRecordCommand(Id));
            return NoContent();
        }
    }
}
