using Refactor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor.Entities
{
    public class CouponDiscount : IDiscount
    {
        public string Name => "Coupon Discount";
        private readonly decimal _amount;

        public CouponDiscount(decimal amount)
        {
            _amount = amount;
        }

        public decimal ApplyDiscount(decimal totalAmount)
        {
            return totalAmount - _amount;
        }
    }
}
