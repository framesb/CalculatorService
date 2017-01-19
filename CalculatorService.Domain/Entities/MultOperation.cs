using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Domain.Entities
{
    public class MultOperation : OperationBase
    {
        public override string Operation => "Mult";
        public List<int> Factors { get; set; }

        public MultOperation()
        {
        }
        public MultOperation(List<int> factors)
        {
            if(factors == null || factors.Count==0)
                throw new ArgumentNullException(nameof(factors));
            else if(factors.Count<2)
                throw new ArgumentException("A Mult Operation needs at least 2 factors");
            Factors = factors;
        }

        public override IOperationResult Execute()
        {
            var result = 1;
            foreach (var factor in Factors)
            {
                result *= factor;
            }
            OperationResult = new MultOperationResult(result);
            return OperationResult;
        }

        protected override string PrintCalculation()
        {
            StringBuilder sb = new StringBuilder();
            if (OperationResult != null)
            {
                foreach (var factor in Factors)
                {
                    if (Factors.IndexOf(factor) == Factors.Count - 1)
                        sb.AppendFormat("{0} = ", factor);
                    else
                        sb.AppendFormat("{0} * ", factor);
                }
                sb.Append((OperationResult as MultOperationResult).Product);
            }
            return sb.ToString();
        }
    }
}
