using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TestProject.Models
{
    public partial class PaymentState
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public string PaymentStatus { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
