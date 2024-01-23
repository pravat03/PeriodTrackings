using CloudVOffice.Core.Domain.Users;
using CloudVOffice.Core.Infrastructure.Applications;
using CloudVOffice.Core.Infrastructure.Http;
using CloudVOffice.Core.Infrastructure.JSON;
using CloudVOffice.Data.DTO.Permission;
using CloudVOffice.Services.Applications;
using CloudVOffice.Services.Plugins;
using CloudVOffice.Services.Roles;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyclePredictor.Controllers
{
    [Area(AreaNames.CyclePredictor)]
    public class CyclePredictorDashboardController : BasePluginController
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public CyclePredictorDashboardController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View("~/Plugins/CyclePredictor/Views/CyclePredictorDashboard/Dashboard.cshtml");
        }
    }
}
