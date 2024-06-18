using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor.Interfaces
{
    public interface IDiscount
    {
        string Name { get; }
        decimal ApplyDiscount(decimal totalAmount);
    }
}
