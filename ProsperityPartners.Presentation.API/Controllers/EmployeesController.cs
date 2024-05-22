using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProsperityPartners.Application.Features.EmployeeFeatures.Commands;
using ProsperityPartners.Application.Features.EmployeeFeatures.Queries;
using ProsperityPartners.Application.Shared.EmployeeDTOs;

namespace ProsperityPartners.Presentation.API.Controllers
{
    [Route("api/companies/{companyId:guid}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ISender _sender;

        public EmployeesController(ISender sender) => _sender = sender;

        [HttpGet]
        public async Task<IActionResult> GetEmployeesForCompany(Guid companyId) 
        {
            var employees = await _sender.Send(new GetEmployeesQuery()
            {
                CompanyId = companyId
            });

            return Ok(employees);
        }

        [HttpGet("{Id:guid}",Name ="GetEmployee")]
        public async Task<IActionResult> GetEmployeeForCompany(Guid companyId, Guid Id)
        {
            var employee = await _sender.Send(new GetEmployeeQuery()
            {
                CompanyId = companyId,
                EmployeeId = Id
            });
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Guid companyId, 
            [FromBody] CreateEmployeeDto createEmployeeDto)
        {
            var createdEmployee = await _sender.Send(new CreateEmployeeCommand
            (
                companyId,
                createEmployeeDto
            ));
            return CreatedAtRoute("GetEmployee",
                new {companyId,id=createdEmployee.Id},createdEmployee);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee(Guid companyId, Guid id)
        {
            await _sender.Send(new DeleteEmployeeCommand(companyId, id));
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee(Guid companyId, Guid id,
            [FromBody] UpdateEmployeeDto updateEmployeeDto)
        {
            if (updateEmployeeDto is null)
                return BadRequest("UpdateEmployeeDto is null.");

            await _sender.Send(new UpdateEmployeeCommand(companyId,employeeId:id,updateEmployeeDto));
            return NoContent();
        }
    }
}
