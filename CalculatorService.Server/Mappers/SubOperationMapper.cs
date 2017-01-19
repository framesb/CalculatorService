using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalculatorService.Server.Models;

namespace CalculatorService.Server.Mappers
{
    public class SubOperationMapper
    {
        public static Domain.Entities.SubOperation Map(SubOperationDTO subOperation)
        {
            return new Domain.Entities.SubOperation(subOperation.Minuend, subOperation.Subtrahend);
        }
    }
}