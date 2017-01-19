using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Domain.Entities
{
    public class DivOperation : OperationBase
    {
        public override string Operation => "Div";

        public int Dividend { get; set; }
        public int Divisor { get; set; }

        public DivOperation()
        {
        }

        public DivOperation(int dividend, int divisor)
        {
            Dividend = dividend;
            Divisor = divisor;
        }
        public override IOperationResult Execute()
        {
            OperationResult = new DivOperationResult(Dividend / Divisor, Dividend % Divisor);
            return OperationResult;
        }

        protected override string PrintCalculation()
        {
            string result = null;
            if (OperationResult != null)
            {
                var operationResult = OperationResult as DivOperationResult;
                result = string.Format("{0} / {1} = {2}, Remainder = {3} ", Dividend, Divisor, operationResult.Quotient, operationResult.Remainder);
            }
            return result;
        }
    }
}
