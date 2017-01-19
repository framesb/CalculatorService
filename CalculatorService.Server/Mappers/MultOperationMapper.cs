using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalculatorService.Server.Models;

namespace CalculatorService.Server.Mappers
{
    public static class MultOperationMapper
    {
        public static Domain.Entities.MultOperation Map(MultOperationDTO operation)
        {
            return new Domain.Entities.MultOperation(operation.Factors);
        }
    }
}