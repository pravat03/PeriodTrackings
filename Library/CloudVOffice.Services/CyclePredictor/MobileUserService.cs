using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.CyclePredictor;
using CloudVOffice.Data.DTO.CyclePredictor;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.CyclePredictor
{
    public class MobileUserService : IMobileUserService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<MobileUser> _mobileuserRepo;
        public MobileUserService(ApplicationDBContext dBContext, ISqlRepository<MobileUser> mobileuserRepo)
        {
            _dbContext = dBContext;
            _mobileuserRepo = mobileuserRepo;
        }

        public MobileUser GetMobileUser()
        {
            try
            {
                return _dbContext.MobileUsers.Where(c => c.Deleted == false).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public MobileUser GetMobileUserByMobileUserId(int mobileUserId)
        {
            try
            {
                return _dbContext.MobileUsers.Where(x => x.MobileUserId == mobileUserId && x.Deleted == false).SingleOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public List<MobileUser> GetMobileUserList()
        {
            try
            {
                return _dbContext.MobileUsers.Where(x => x.Deleted == false).ToList();
            }
            catch
            {
                throw;
            }
        }

        

        public MessageEnum MobileUserCreate(MobileUserDTO mobileUserDTO)
        {
            var ObjCheck = _dbContext.MobileUsers.FirstOrDefault(opt => opt.Deleted == false);
            try
            {
                if (ObjCheck == null)
                {
                    MobileUser mobileUser = new MobileUser();
                    mobileUser.Name = mobileUserDTO.Name;
                    mobileUser.EmailId = mobileUserDTO.EmailId;
                    mobileUser.DOB = mobileUserDTO.DOB;
                    mobileUser.MobileNo = mobileUserDTO.MobileNo;
                    mobileUser.Password = mobileUserDTO.Password;
                    mobileUser.CreatedBy = mobileUserDTO.CreatedBy;
                    var obj = _mobileuserRepo.Insert(mobileUser);
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

        public MessageEnum MobileUserDelete(int mobileUserId, int DeletedBy)
        {
            try
            {
                var a = _dbContext.MobileUsers.Where(x => x.MobileUserId == mobileUserId).FirstOrDefault();
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

        public MessageEnum MobileUserUpdate(MobileUserDTO mobileUserDTO)
        {
            try
            {

                var a = _dbContext.MobileUsers.Where(x => x.MobileUserId == mobileUserDTO.MobileUserId).FirstOrDefault();
                if (a != null)
                {
                    a.Name = mobileUserDTO.Name;
                    a.EmailId = mobileUserDTO.EmailId;
                    a.DOB = mobileUserDTO.DOB;
                    a.MobileNo = mobileUserDTO.MobileNo;
                    a.Password = mobileUserDTO.Password;
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

        public object Login(string email, string password)
        {
            try
            {
                var user = _dbContext.MobileUsers
                    .Where(x => x.EmailId == email && x.Deleted == false).FirstOrDefault();
                if (user != null)
                {
                    if (user.Password == password)
                    {
                        // Login successful
                        return user;
                    }
                    else
                    {
                        // Incorrect password
                        return null;
                    }
                }
                else
                {
                    // User not found
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }
    }
   }