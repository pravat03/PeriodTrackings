using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.CyclePredictor
{
    public class MobileUser : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 MobileUserId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public DateTime DOB { get; set; }
        public string? MobileNo { get; set; }
        public string Password { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}

