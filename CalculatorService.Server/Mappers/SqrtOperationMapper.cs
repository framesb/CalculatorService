using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalculatorService.Server.Models;

namespace CalculatorService.Server.Mappers
{
    public static class SqrtOperationMapper
    {
        public static Domain.Entities.SqrtOperation Map(SqrtOperationDTO operation)
        {
            return new Domain.Entities.SqrtOperation(operation.Number);
        }
    }
}