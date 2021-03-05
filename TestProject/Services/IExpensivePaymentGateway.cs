using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.Services
{
    interface IExpensivePaymentGateway
    {
        public bool isAvailable { get; }
        public bool ProcessPayment(Payment payment);
    }
}
