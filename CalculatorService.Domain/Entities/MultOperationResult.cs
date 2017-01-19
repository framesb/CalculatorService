using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Domain.Entities
{
    public class MultOperationResult : IOperationResult
    {
        public int Product { get; private set; }

        public MultOperationResult(int product)
        {
            Product = product;
        }
    }
}
