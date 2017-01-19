using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Domain.Entities
{
    public class SubOperation : OperationBase
    {
        public override string Operation => "Sub";

        public int Minuend { get; set; }
        public int Subtrahend { get; set; }

        public SubOperation()
        {
        }

        public SubOperation(int minuend, int subtrahend)
        {
            Minuend = minuend;
            Subtrahend = subtrahend;
        }
        public override IOperationResult Execute()
        {
            OperationResult = new SubOperationResult(Minuend - Subtrahend);
            return OperationResult;
        }

        protected override string PrintCalculation()
        {
            string result = null;
            if (OperationResult != null)
            {
                result = string.Format("{0} - {1} = {2}", Minuend, Subtrahend, (OperationResult as SubOperationResult).Difference);
            }
            return result;
        }
    }
}
