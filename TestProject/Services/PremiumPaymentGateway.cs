using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.Services
{
    public class PremiumPaymentGateway : IPremiumPaymentGateway
    {
        public bool isAvailable { get; } = true;
        public PremiumPaymentGateway() { }

        public bool ProcessPayment(Payment payment)
        {
            return true;
        }
    }
}
