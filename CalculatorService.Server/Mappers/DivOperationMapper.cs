using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalculatorService.Server.Models;

namespace CalculatorService.Server.Mappers
{
    public class DivOperationMapper
    {
        public static Domain.Entities.DivOperation Map(DivOperationDTO operation)
        {
            return new Domain.Entities.DivOperation(operation.Dividend, operation.Divisor);
        }
    }
}