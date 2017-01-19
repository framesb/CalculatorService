using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Domain.Entities
{
    public class SqrtOperation : OperationBase
    {
        public override string Operation => "Sqrt";
        public int Number { get; set; }

        public SqrtOperation()
        {
        }
        public SqrtOperation(int number)
        {
            Number = number;
        }

        public override IOperationResult Execute()
        {
            OperationResult = new SqrtOperationResult((int)Math.Sqrt(Number));
            return OperationResult;
        }

        protected override string PrintCalculation()
        {
            string result = null;
            if (OperationResult != null)
            {
                result = string.Format("Sqrt({0}) = {1}", Number, (OperationResult as SqrtOperationResult).Square);
            }
            return result;
        }
    }
}
