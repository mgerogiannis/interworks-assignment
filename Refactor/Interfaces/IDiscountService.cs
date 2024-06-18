using Refactor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor.Interfaces
{
    public interface IDiscountService
    {
        List<DiscountResult> ApplyDiscounts(decimal totalAmount);
    }
}
