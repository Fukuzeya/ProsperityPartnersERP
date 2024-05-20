using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProsperityPartners.Application.Features.EmployeeFeatures.Queries;

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

        [HttpGet("{Id:guid}")]
        public async Task<IActionResult> GetEmployeeForCompany(Guid companyId, Guid Id)
        {
            var employee = await _sender.Send(new GetEmployeeQuery()
            {
                CompanyId = companyId,
                EmployeeId = Id
            });
            return Ok(employee);
        }

    }
}
