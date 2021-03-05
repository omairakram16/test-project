using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestProject.Helpers.Attributes;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TestProject.Models
{
    public partial class Payment
    {
        public Payment()
        {
            PaymentState = new HashSet<PaymentState>();
        }

        public int Id { get; set; }

        [Required, ValidCreditCard(ErrorMessage = "Invalid credit card number")]
        public string CreditCardNumber { get; set; }

        [Required]
        public string CardHolder { get; set; }

        [Required, NotPastDate(ErrorMessage = "Invalid expiration date")]
        public DateTime? ExpirationDate { get; set; }

        [MaxLength(3), MinLength(3)]
        public string SecurityCode { get; set; }

        [Required]
        public decimal? Amount { get; set; }

        public virtual ICollection<PaymentState> PaymentState { get; set; }
    }
}
