using Refactor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor.Entities
{
    public class PriceListDiscount : IDiscount
    {
        public string Name => "Price List Discount";
        private readonly decimal _percentage;

        public PriceListDiscount(decimal percentage)
        {
            _percentage = percentage;
        }

        public decimal ApplyDiscount(decimal totalAmount)
        {
            return totalAmount * (1 - _percentage / 100);
        }
    }
}
