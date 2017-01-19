using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Domain.Entities
{
    public interface IOperation
    {
        string Operation { get; set; }
        IOperationResult Execute();
    }

    public abstract class OperationBase : IOperation
    {
        public virtual string Operation { get; set; }

        private string calculation;
        public string Calculation
        {
            get
            {
                if(string.IsNullOrEmpty(calculation))
                    calculation = PrintCalculation();
                return calculation;
            }
            set { calculation = value; }
        }

        public DateTime Date { get; set; }

        public OperationBase()
        {
            Date = DateTime.Now;
        }

        protected IOperationResult OperationResult { get; set; }
        protected abstract string PrintCalculation();
        public abstract IOperationResult Execute();
    }
}
