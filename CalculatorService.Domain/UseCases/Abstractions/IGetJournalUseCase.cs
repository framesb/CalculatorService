using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorService.Domain.Entities;

namespace CalculatorService.Domain.UseCases.Abstractions
{
    public interface IGetJournalUseCase
    {
        ClientOperations Execute(QueryOperation queryOperation);
    }
}
