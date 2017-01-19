using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Domain.Entities
{
    public class DivOperationResult : IOperationResult
    {
        public int Quotient { get; private set; }
        public int Remainder { get; private set; }

        public DivOperationResult(int quotient, int remainder)
        {
            Quotient = quotient;
            Remainder = remainder;
        }
    }
}
