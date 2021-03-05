using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.Services
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        public bool isAvailable { get; } = false;
        public ExpensivePaymentGateway() { }

        public bool ProcessPayment(Payment payment)
        {
            return true;
        }
    }
}
