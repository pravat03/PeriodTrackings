using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.CyclePredictor;
using CloudVOffice.Data.DTO.CyclePredictor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.CyclePredictor
{
    public interface IMobileUserService
    {
        public MessageEnum MobileUserCreate(MobileUserDTO mobileUserDTO);
        public MobileUser GetMobileUserByMobileUserId(int mobileUserId);
        public List<MobileUser> GetMobileUserList();
        public MobileUser GetMobileUser();
        public MessageEnum MobileUserUpdate(MobileUserDTO mobileUserDTO);
        public MessageEnum MobileUserDelete(int mobileUserId, int DeletedBy);
        object Login(string email, string password);
    }
}
