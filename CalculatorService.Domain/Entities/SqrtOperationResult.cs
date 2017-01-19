using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Domain.Entities
{
    public class SqrtOperationResult : IOperationResult
    {
        public int Square { get; private set; }

        public SqrtOperationResult(int square)
        {
            Square = square;
        }
    }
}
