using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Company;
using CloudVOffice.Core.Domain.CyclePredictor;
using CloudVOffice.Data.DTO.Company;
using CloudVOffice.Data.DTO.CyclePredictor;

namespace CloudVOffice.Services.CyclePredictor
{
	public interface IExpertService
	{
		public MessageEnum ExpertCreate(ExpertDTO expertDTO);
		public Expert GetExpertByExpertId(int expertId);
		public List<Expert> GetExpertList();
		public Expert GetExpert();
		public MessageEnum ExpertUpdate(ExpertDTO expertDTO);
		public MessageEnum ExpertDelete(int expertId, Int64 DeletedBy);
	}
}
