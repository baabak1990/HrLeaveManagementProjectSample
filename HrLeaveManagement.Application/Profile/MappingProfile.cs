using Hr.LeaveManagement.Domain.Entity.LeaveEntities;
using HrLeaveManagement.Application.DTOs.LeaveAllocations;
using HrLeaveManagement.Application.DTOs.LeaveRequests;
using HrLeaveManagement.Application.DTOs.LeaveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Profile
{
    public class MappingProfile:AutoMapper.Profile
    {
        public MappingProfile()
        {
            #region LeaveAllocations

            CreateMap<LeaveAllocation, LeaveAllocationDTO>().ReverseMap();
            CreateMap<LeaveAllocation, CreateLeaveAllocationDTO>().ReverseMap();
            CreateMap<LeaveAllocation, UpdateLeaveAllocationDTO>().ReverseMap();

            #endregion
            #region LeaveRequest
            
            CreateMap<LeaveRequest, LeaveRequestDTO>().ReverseMap();
            CreateMap<LeaveRequest, ChangeleaveRequestApprovalDTO>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDTo>().ReverseMap();
            CreateMap<LeaveRequest, CreateRequestTypeDTO>().ReverseMap();
            CreateMap<LeaveRequest, UpdateleaveRequestDTO>().ReverseMap();

            #endregion
            #region LeaveTypes

            CreateMap<LeaveType, LeaveTypeDTo>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDTO>().ReverseMap();

            #endregion
        }
    }
}
