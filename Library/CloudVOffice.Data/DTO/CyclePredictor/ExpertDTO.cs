using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.CyclePredictor
{
	public class ExpertDTO
	{
		public int ExpertId { get; set; }
		public string ExpertName { get; set; }
		public string Age { get; set; }
		public string Gender { get; set; }
		public string Mailid { get; set; }
		//public string? Domain { get; set; }
		public Int64 CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public Int64? UpdatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public bool Deleted { get; set; }
	}
}
