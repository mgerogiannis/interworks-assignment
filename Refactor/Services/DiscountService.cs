using Refactor.Entities;
using Refactor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly List<IDiscount> _discounts;

        public DiscountService(List<IDiscount> discounts)
        {
            _discounts = discounts;
        }

        public List<DiscountResult> ApplyDiscounts(decimal totalAmount)
        {
            var results = new List<DiscountResult>();
            decimal currentTotal = totalAmount;

            foreach (var discount in _discounts)
            {
                decimal newTotal = discount.ApplyDiscount(currentTotal);
                results.Add(new DiscountResult
                {
                    DiscountName = discount.Name,
                    DiscountAmount = currentTotal - newTotal,
                    TotalAfterDiscount = newTotal
                });
                currentTotal = newTotal;
            }

            return results;
        }
    }
}
