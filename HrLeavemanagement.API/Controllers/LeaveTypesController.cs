using HrLeaveManagement.Application.DTOs.LeaveTypes;
using HrLeaveManagement.Application.Features.LeaveTypes.Request.Command;
using HrLeaveManagement.Application.Features.LeaveTypes.Request.Querries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HrLeavemanagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
        // GET: api/<LeaveTypesController>
        public LeaveTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDTo>>> Get()
        {
            var leaveTypes =await _mediator.Send(new GetLeaveTypeDToListRequest());
            return Ok(leaveTypes);
        }

        // GET api/<LeaveTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDTo>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeRequest { Id = id });
            if (leaveType == null)
            {
                return NotFound();
            }
            return Ok(leaveType);
        }

        // POST api/<LeaveTypesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LeaveTypeDTo model)
        {
            var command = new CreateLeaveTypeCommand() { LeaveTypeDTo = model };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveTypesController>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put( [FromBody] LeaveTypeDTo model)
        {
            var command = new UpdateLeaveTypeCommand() { LeaveTypeDTo = model };
            var response =await  _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveTypeCommand() { id = id };
            var response= await _mediator.Send(command);
            return NoContent();
        }
    }
}
