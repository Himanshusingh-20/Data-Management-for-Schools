using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkXyz.UI.Validation
{
    public class FirstLetterUpperCaseAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string textboxvalue = value.ToString();
                if (!String.IsNullOrEmpty(textboxvalue))
                {
                    char firstvalue = textboxvalue[0];
                    if (char.IsUpper(firstvalue))
                    {
                        return ValidationResult.Success;
                    }
                }
            }
            return new ValidationResult(ErrorMessage ?? "The first letter must be upper case");

        }

    }
}
