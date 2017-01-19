using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Domain.Entities
{
    public class SubOperationResult : IOperationResult
    {
        public int Difference { get; private set; }

        public SubOperationResult(int difference)
        {
            Difference = difference;
        }
    }
}
