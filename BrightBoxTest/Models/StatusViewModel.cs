using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrightBoxTest.Models
{
    public class StatusViewModel
    {
        [Display(Name = "Статус")]
        public StatusKey StatusKey { get; set; }

        [WorkDateTimeRequired(ErrorMessage = "Необходимо заполнить дату планируемых работ")]
        [Display(Name = "Дата планируемых работ")]
        public DateTime? WorkDateTime { get; set; }

        public IEnumerable<SelectListItem> StatusKeysDictionary
        {
            get
            {
                return Enum.GetValues(typeof(StatusKey)).Cast<StatusKey>().Select(s => new SelectListItem
                {
                    Value = s.ToString(),
                    Text = s.GetDescription(),
                    Selected = s == StatusKey
                });
            }
        }
    }
}