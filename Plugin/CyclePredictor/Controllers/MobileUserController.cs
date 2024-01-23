using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Data.DTO.CyclePredictor;
using CloudVOffice.Services.CyclePredictor;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyclePredictor.Controllers
{
    [Area(AreaNames.CyclePredictor)]
    public class MobileUserController : BasePluginController
    {
        private readonly IMobileUserService _mobileUserService;
        public MobileUserController(IMobileUserService mobileUserService)
        {
            _mobileUserService = mobileUserService;
        }

        public IActionResult MobileUserView()
        {
            ViewBag.mobileuser = _mobileUserService.GetMobileUserList();
            return View("~/Plugins/CyclePredictor/Views/MobileUser/MobileUserView.cshtml");
        }
    }
}
