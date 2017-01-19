using System.Collections.Generic;
using CalculatorService.Domain.Entities;

namespace CalculatorService.Domain.Adapters.Data
{
    public interface IClientOperationsRepository
    {
        ClientOperations GetOperations(string clientId);

        void Save(string clientId, IOperation operation);
    }
}
