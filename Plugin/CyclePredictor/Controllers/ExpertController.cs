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
	public class ExpertController :  BasePluginController
	{
		private readonly IExpertService _expertService;
		public ExpertController(IExpertService expertService)
		{
			_expertService = expertService;
		}
		[HttpGet]
		public IActionResult CreateExpert(int? expertId)
		{
			ExpertDTO expertDTO = new ExpertDTO();
			if (expertId !=null)
			{
				var target = _expertService.GetExpertByExpertId(int.Parse(expertId.ToString()));
				expertDTO.ExpertName = target.ExpertName;
				expertDTO.Age = target.Age;
				expertDTO.Gender = target.Gender;
				expertDTO.Mailid = target.Mailid;
			}
			return View("~/Plugins/CyclePredictor/Views/Expert/CreateExpert.cshtml", expertDTO);
		}

		[HttpPost]
		public IActionResult CreateExpert(ExpertDTO expertDTO)
		{
			expertDTO.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());



			if (expertDTO.ExpertId == null)
			{
				var a = _expertService.ExpertCreate(expertDTO);
				if (a == MessageEnum.Success)
				{
					TempData["msg"] = MessageEnum.Success;
					return Redirect("/SalesExecutive/SalesAdmin/SalesAdminTargetView");
				}
				else if (a == MessageEnum.Duplicate)
				{

					TempData["msg"] = MessageEnum.Duplicate;
					ModelState.AddModelError("", "PinCode Already Exists");
				}
				else
				{
					TempData["msg"] = MessageEnum.UnExpectedError;
					ModelState.AddModelError("", "Un-Expected Error");
				}
			}
			else
			{
				var a = _expertService.ExpertUpdate(expertDTO);
				if (a == MessageEnum.Updated)
				{
					TempData["msg"] = MessageEnum.Updated;
					return Redirect("/CyclePredictor/Expert/SalesAdminTargetView");
				}
				else if (a == MessageEnum.Duplicate)
				{
					TempData["msg"] = MessageEnum.Duplicate;
					ModelState.AddModelError("", "PinCode Already Exists");
				}
				else
				{
					TempData["msg"] = MessageEnum.UnExpectedError;
					ModelState.AddModelError("", "Un-Expected Error");
				}
			}

			return View("~/Plugins/CyclePredictor/Views/Expert/CreateExpert.cshtml", expertDTO);
		}


		public IActionResult ExpertView()
		{
			ViewBag.exper= _expertService.GetExpertList();

			return View("~/Plugins/CyclePredictor/Views/Expert/ExpertView.cshtml");
		}

		[HttpGet]
		public IActionResult ExpertDelete(int expertId)
		{
			Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			var a = _expertService.ExpertDelete(expertId, DeletedBy);
			return Redirect("/CyclePredictor/Expert/SalesAdminTargetView");
		}
	}
}
