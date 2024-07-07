using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
	public class Min18YearsIfAMember : ValidationAttribute
	{

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MemberShipTypeId == MemberShipType.Unknown||
                customer.MemberShipTypeId == MemberShipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.BirthDate == null)
                return new ValidationResult("Birthdate is requried");

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be atleast 18 to go on a membership."); 
        }

        public Min18YearsIfAMember()
		{
		}
	}
}

