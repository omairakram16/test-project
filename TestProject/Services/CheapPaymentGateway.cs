using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.Services
{
    public class CheapPaymentGateway : ICheapPaymentGateway
    {
        public bool isAvailable { get; } = true;
        public CheapPaymentGateway() { }

        public bool ProcessPayment(Payment payment)
        {
            return true;
        }
    }
}
