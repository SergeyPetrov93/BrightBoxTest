using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrightBoxTest.Models
{
    public class WorkDateTimeRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var workDateTime = value as DateTime?;

            if (!workDateTime.HasValue)
            {
                var propertyStatusKey = validationContext.ObjectType.GetProperty("StatusKey");

                if (propertyStatusKey != null)
                {
                    var statusKey = (StatusKey)propertyStatusKey.GetValue(validationContext.ObjectInstance, null);

                    if (statusKey == StatusKey.AvailableWorkPlaned)
                    {
                        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                    }
                }
            }

            return null;
        }
    }
}