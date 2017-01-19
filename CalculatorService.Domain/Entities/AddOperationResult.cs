using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Domain.Entities
{
    public class AddOperationResult : IOperationResult
    {
        public int Sum { get; private set; }

        public AddOperationResult(int sum)
        {
            Sum = sum;
        }
    }
}
