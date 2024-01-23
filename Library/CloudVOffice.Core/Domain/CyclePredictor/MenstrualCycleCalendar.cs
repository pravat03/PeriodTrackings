using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.CyclePredictor
{
    public class MenstrualCycleCalendar : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 MenstrualCycleCalendarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set;}
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }

    }
}
