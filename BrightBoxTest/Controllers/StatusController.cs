using BrightBoxTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Http;
using System.Web.Http.Results;

namespace BrightBoxTest.Controllers
{
    public class StatusController : ApiController
    {
        /// <summary>
        /// Возвращает значение текущего статуса
        /// </summary>
        /// <returns></returns>
        public StatusResponse Get()
        {
            var dbContext = HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>();

            var currentStatus = dbContext.Set<Status>()
                .Select(status => new
                {
                    Status = status.StatusKey,
                    WorkDateTime = status.WorkDateTime ?? default(DateTime)
                })
                .SingleOrDefault();

            var result = new StatusResponse
            {
                StatusKey = currentStatus != null
                    ? currentStatus.Status
                    : StatusKey.NotAvailable,

                WorkDateTime = currentStatus != null
                    ? currentStatus.WorkDateTime
                    : default(DateTime)
            };

            return result;
        }
    }
}