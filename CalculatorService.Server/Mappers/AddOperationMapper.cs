using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalculatorService.Server.Models;

namespace CalculatorService.Server.Mappers
{
    public static class AddOperationMapper
    {
        public static Domain.Entities.AddOperation Map(AddOperationDTO addOperation)
        {
            return new Domain.Entities.AddOperation(addOperation.Addends);
        }
    }
}