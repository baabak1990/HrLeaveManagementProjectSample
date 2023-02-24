using HrLeaveManagement.Application.DTOs.LeaveAllocations;
using HrLeaveManagement.Application.DTOs.LeaveRequests;
using HrLeaveManagement.Application.Features.leaveAllocations.Request.Command;
using HrLeaveManagement.Application.Features.leaveAllocations.Request.Querries;
using HrLeaveManagement.Application.Features.LeaveTypes.Request.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HrLeavemanagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveAllocationController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDTO>>> Get()
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListRequest());
            return Ok(leaveAllocations);
        }

        // GET api/<LeaveAllocationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDTO>> Get(int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationByIdRequest() { Id = id });
            if (leaveAllocation==null)
            {
                return NotFound();
            }
            return Ok(leaveAllocation);
        }

        // POST api/<LeaveAllocationController>
        [HttpPost]
        public async Task<ActionResult<LeaveAllocationDTO>> Post([FromBody] LeaveAllocationDTO model)
        {
            var command = new CreateLeaveAllocationCommand() { LeaveAllocationDto = model };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveAllocationController>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put( [FromBody] LeaveAllocationDTO model)
        {
            var command = new UpdateLeaveAllocationCommand() { LeaveAllocationDto = model };
            var response= await _mediator.Send(command);
            return NoContent();
        }
       
        // DELETE api/<LeaveAllocationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveAllocationCommand() { id = id };
            var response= _mediator.Send(command);
            return NoContent();
        }
    }
}
