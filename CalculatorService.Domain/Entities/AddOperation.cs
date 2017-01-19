using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Domain.Entities
{
    public class AddOperation : OperationBase
    {
        public override string Operation => "Sum";
        public List<int> Addends { get; set; }

        public AddOperation()
        {
        }
        public AddOperation(List<int> addends)
        {
            if(addends==null || addends.Count==0)
                throw new ArgumentNullException(nameof(addends));
            else if(addends.Count<2)
                throw new ArgumentException("An Add Operation needs at least 2 addends");
            Addends = addends;
        }

        public override IOperationResult Execute()
        {
            OperationResult = new AddOperationResult(Addends.Sum());
            return OperationResult;
        }

        protected override string PrintCalculation()
        {
            StringBuilder sb = new StringBuilder();
            if (OperationResult != null)
            {
                foreach (var addend in Addends)
                {
                    if (Addends.IndexOf(addend) == Addends.Count - 1)
                        sb.AppendFormat("{0} = ", addend);
                    else
                        sb.AppendFormat("{0} + ", addend);
                }
                sb.Append((OperationResult as AddOperationResult).Sum);
            }


            return sb.ToString();
        }
    }
}
