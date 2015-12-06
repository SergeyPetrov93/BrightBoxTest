using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrightBoxTest.Models
{
    public class StatusResponse
    {
        /// <summary>
        /// Текущий статус работ
        /// </summary>
        public StatusKey StatusKey { get; set; }

        /// <summary>
        /// Дата планируемых работ
        /// </summary>
        public DateTime WorkDateTime { get; set; }
    }
}