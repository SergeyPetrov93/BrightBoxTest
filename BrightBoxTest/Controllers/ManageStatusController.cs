using BrightBoxTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace BrightBoxTest.Controllers
{
    public class ManageStatusController : Controller
    {
        [HttpGet]
        [Authorize]
        public ActionResult ManageStatus()
        {
            var dbContext = HttpContext.GetOwinContext().Get<ApplicationDbContext>();

            var currentStatus = dbContext.Set<Status>().AsNoTracking().SingleOrDefault();

            var viewModel = new StatusViewModel();

            if (currentStatus != null)
            {
                viewModel.StatusKey = currentStatus.StatusKey;
                viewModel.WorkDateTime = currentStatus.WorkDateTime;
            }

            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult ManageStatus(StatusViewModel viewModel)
        {

            if (!ViewData.ModelState.IsValid)
                return View(viewModel);

            var dbContext = HttpContext.GetOwinContext().Get<ApplicationDbContext>();

            var currentStatus = dbContext.Set<Status>().SingleOrDefault();

            if (currentStatus != null)
            {
                currentStatus.StatusKey = viewModel.StatusKey;
                currentStatus.WorkDateTime = viewModel.WorkDateTime;
            }
            else
            {
                dbContext.Set<Status>().Add(new Status
                {
                    StatusKey = viewModel.StatusKey,
                    WorkDateTime = viewModel.WorkDateTime
                });
            }

            dbContext.SaveChanges();

            return View("Success");
        }
    }
}