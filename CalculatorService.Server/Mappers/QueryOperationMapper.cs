using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalculatorService.Server.Models;

namespace CalculatorService.Server.Mappers
{
    public static class QueryOperationMapper
    {
        public static Domain.Entities.QueryOperation Map(QueryOperationDTO operation)
        {
            return new Domain.Entities.QueryOperation(operation.ClientId);
        }
    }
}