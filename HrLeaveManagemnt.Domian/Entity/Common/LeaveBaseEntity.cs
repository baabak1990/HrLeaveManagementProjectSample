using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveManagement.Domain.Entity.Common
{
    public abstract class LeaveBaseEntity<T> where T : struct
    {
        [Key]
        public T Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string? ModifiedBy { get; set; }

    }
}
