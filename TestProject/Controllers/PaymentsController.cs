using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestProject.Models;
using TestProject.Services;
using TestProject.ViewModels;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly test_1Context _context;

        public PaymentsController(test_1Context context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
            var payment = await _context.Payment.FindAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        // POST: api/Payments
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {
            if(this.ModelState.IsValid)
            {
                _context.Payment.Add(payment);
                PaymentState paymentState = new PaymentState { Payment = payment, PaymentStatus = PaymentStatus.Pending };
                _context.PaymentState.Add(paymentState);
                await _context.SaveChangesAsync();

                if(payment.Amount <= 20)
                {
                    ICheapPaymentGateway cheapPaymentGateway = new CheapPaymentGateway();
                    bool paymentProcessStatus = cheapPaymentGateway.ProcessPayment(payment);
                    if(paymentProcessStatus)
                    {
                        paymentState.PaymentStatus = PaymentStatus.Processed;
                        _context.Entry(paymentState).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    } else
                    {
                        paymentState.PaymentStatus = PaymentStatus.Failed;
                        _context.Entry(paymentState).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }
                else if(payment.Amount > 20 && payment.Amount <= 500)
                {
                    IExpensivePaymentGateway expensivePaymentGateway = new ExpensivePaymentGateway();
                    if(expensivePaymentGateway.isAvailable)
                    {
                        bool paymentProcessStatus = expensivePaymentGateway.ProcessPayment(payment);
                        if (paymentProcessStatus)
                        {
                            paymentState.PaymentStatus = PaymentStatus.Processed;
                            _context.Entry(paymentState).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            paymentState.PaymentStatus = PaymentStatus.Failed;
                            _context.Entry(paymentState).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                        }
                    } else
                    {
                        ICheapPaymentGateway cheapPaymentGateway = new CheapPaymentGateway();
                        bool paymentProcessStatus = cheapPaymentGateway.ProcessPayment(payment);
                        if (paymentProcessStatus)
                        {
                            paymentState.PaymentStatus = PaymentStatus.Processed;
                            _context.Entry(paymentState).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            paymentState.PaymentStatus = PaymentStatus.Failed;
                            _context.Entry(paymentState).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                else if (payment.Amount > 500)
                {
                    IPremiumPaymentGateway premiumPaymentGateway = new PremiumPaymentGateway();
                    bool paymentProcessStatus = false;
                    for (int i=0; i < 3; i++)
                    {
                        paymentProcessStatus = premiumPaymentGateway.ProcessPayment(payment);
                        if(paymentProcessStatus)
                        {
                            break;
                        }
                    }
                    if(paymentProcessStatus)
                    {
                        paymentState.PaymentStatus = PaymentStatus.Processed;
                        _context.Entry(paymentState).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        paymentState.PaymentStatus = PaymentStatus.Failed;
                        _context.Entry(paymentState).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }

                }

                return CreatedAtAction("GetPayment", new { id = payment.Id }, payment);
            }

            return BadRequest(this.ModelState); 
        }

    }
}
