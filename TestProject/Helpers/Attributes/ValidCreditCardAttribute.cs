using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Helpers.Attributes
{
    public class ValidCreditCardAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)// Return a boolean value: true == IsValid, false != IsValid
        {
            string d = Convert.ToString(value);
            return d.Length >= 13; //Dates Greater than or equal to today are valid (true)
        }
    }
}
