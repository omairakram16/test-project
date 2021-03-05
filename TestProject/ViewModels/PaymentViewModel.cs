using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Models;
using TestProject.Services;

namespace TestProject.ViewModels
{
    public static class PaymentStatus
    {
        public const string Pending  = "pending";
        public const string Processed = "processed";
        public const string Failed  = "failed";
    }
}
