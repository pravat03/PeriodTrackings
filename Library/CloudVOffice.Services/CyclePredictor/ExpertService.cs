using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.CyclePredictor;
using CloudVOffice.Data.DTO.CyclePredictor;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;

namespace CloudVOffice.Services.CyclePredictor
{
	public class ExpertService : IExpertService
	{
		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<Expert> _expertRepo;
		public ExpertService(ApplicationDBContext dbContext, ISqlRepository<Expert> expertRepo)
		{

			_dbContext = dbContext;
			_expertRepo = expertRepo;
		}
		public MessageEnum ExpertCreate(ExpertDTO expertDTO)
		{
			var ObjCheck = _dbContext.Experts.FirstOrDefault(opt => opt.Deleted == false);
			try
			{ 
			if (ObjCheck == null)
			{
					Expert expert = new Expert();
					expert.ExpertName = expertDTO.ExpertName;
					expert.Age = expertDTO.Age;
					expert.Gender = expertDTO.Gender;
					expert.Mailid = expertDTO.Mailid;
					expert.CreatedBy = expertDTO.CreatedBy;
					var obj = _expertRepo.Insert(expert);

				return MessageEnum.Success;
			}
			else if (ObjCheck != null)
			{
				return MessageEnum.AlreadyCreate;
			}
			return MessageEnum.UnExpectedError;
			}
			catch
			{
				throw;
			}
		}

		public MessageEnum ExpertDelete(int expertId, Int64 DeletedBy)
		{
			{
				try
				{
					var a = _dbContext.Experts.Where(x => x.ExpertId == expertId).FirstOrDefault();
					if (a != null)
					{
						a.Deleted = true;
						a.UpdatedBy = DeletedBy;
						a.UpdatedDate = DateTime.Now;
						_dbContext.SaveChanges();
						return MessageEnum.Deleted;
					}
					else
						return MessageEnum.Invalid;
				}
				catch
				{
					throw;
				}
			}
		}

		public MessageEnum ExpertUpdate(ExpertDTO expertDTO)
		{
			{
				try
				{

					var a = _dbContext.Experts.Where(x => x.ExpertId == expertDTO.ExpertId).FirstOrDefault();
					if (a != null)
					{
						a.ExpertName = expertDTO.ExpertName;
						a.Age = expertDTO.Age;
						a.Gender = expertDTO.Gender;
						a.Mailid = expertDTO.Mailid;
						a.UpdatedDate = DateTime.Now;
						_dbContext.SaveChanges();
						return MessageEnum.Updated;
					}
					else
						return MessageEnum.Invalid;
				}
				catch
				{
					throw;
				}
			}
		}

		public Expert GetExpert()
		{
			try
			{
				return _dbContext.Experts.Where(c => c.Deleted == false).FirstOrDefault();
			}
			catch
			{
				throw;
			}
		}

		public Expert GetExpertByExpertId(int expertId)
		{
			try
			{
				return _dbContext.Experts.Where(x => x.ExpertId == expertId && x.Deleted == false).SingleOrDefault();

			}
			catch
			{
				throw;
			}
		}

		public List<Expert> GetExpertList()
		{
			try
			{
				return _dbContext.Experts.Where(x => x.Deleted == false).ToList();
			}
			catch
			{
				throw;
			}
		}
	}
}
