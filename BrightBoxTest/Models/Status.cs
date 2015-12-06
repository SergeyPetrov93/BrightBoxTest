using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrightBoxTest.Models
{
    public class Status
    {
        public int Id { get; set; }
        public StatusKey StatusKey { get; set; }

        [WorkDateTimeRequired(ErrorMessage = "Необходимо заполнить дату планируемых работ")]
        public DateTime? WorkDateTime { get; set; }
    }

    public enum StatusKey : byte
    {
        /// <summary>
        /// Сервис недоступен, ведутся технические работы.
        /// </summary>
        [Description("Сервис недоступен, ведутся технические работы.")]
        NotAvailable = 0,

        /// <summary>
        /// Все работает штатно, работы по обновлению не ведутся.
        /// </summary>
        [Description("Все работает штатно, работы по обновлению не ведутся.")]
        Available = 1,

        /// <summary>
        /// Сейчас все работает штатно, но запланированы работы.
        /// </summary>
        [Description("Сейчас все работает штатно, но запланированы работы.")]
        AvailableWorkPlaned = 2
    }
}