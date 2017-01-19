using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Domain.Entities
{
    public class QueryOperation
    {
        public string ClientId { get; set; }

        public QueryOperation()
        {
        }
        public QueryOperation(string clientId)
        {
            if(string.IsNullOrEmpty(clientId))
                throw new ArgumentNullException(nameof(clientId));
            ClientId = clientId;
        }

        //public IOperationResult Execute()
        //{
        //    OperationResult = new QueryOperationResult(Addends.Sum());
        //    return OperationResult;
        //}

        //protected override string PrintCalculation()
        //{
        //    return string.Empty;
        //}
    }
}
