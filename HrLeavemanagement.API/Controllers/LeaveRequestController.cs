using HrLeaveManagement.Application.DTOs.LeaveRequests;
using HrLeaveManagement.Application.Features.LeaveRequests.Request.Command;
using HrLeaveManagement.Application.Features.LeaveTypes.Request.Querries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HrLeavemanagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        // GET: api/<LeaveRequestController>
        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestDTO>>> Get()
        {
            var leaveRequests = await _mediator.Send(new GetLeaveTypeDToListRequest());
            return Ok(leaveRequests);
        }

        // GET api/<LeaveRequestController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDTO>> Get(int id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveTypeRequest() { Id = id });
            return Ok(leaveRequest);
        }

        // POST api/<LeaveRequestController>
        [HttpPost]
        public async Task<ActionResult<LeaveRequestDTO>> Post([FromBody] LeaveRequestDTO model)
        {
            var command = new CreateLeaveRequestCommand() { LeaveRequest = model };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveRequestController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] LeaveRequestDTO model)
        {
            var command = new UpdateLeaveRequestCommand() { id = id, LeaveRequestDto = model };
            var response = await _mediator.Send(command);
            return NoContent();
        }

        // PUT api/<LeaveRequestController>/5
        [HttpPut("ChangeApproval/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ChangeleaveRequestApprovalDTO model)
        {
            var command = new UpdateLeaveRequestCommand() { id = id, ChangeleaveRequestApprovalDto = model };
            var response = await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveRequestController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommand() { id = id };
            var response = await _mediator.Send(command);
            return NoContent();
        }
    }
}
