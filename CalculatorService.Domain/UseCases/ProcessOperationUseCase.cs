using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorService.Domain.Adapters.Data;
using CalculatorService.Domain.Entities;
using CalculatorService.Domain.UseCases.Abstractions;

namespace CalculatorService.Domain.UseCases
{
    public class ProcessOperationUseCase : IProcessOperationUseCase
    {
        IClientOperationsRepository clientOperationsRepository;

        public ProcessOperationUseCase(IClientOperationsRepository clientOperationsRepository)
        {
            this.clientOperationsRepository = clientOperationsRepository;
        }

        public IOperationResult Execute(IOperation operation, string clientId)
        {

            var result = operation.Execute();
            if (!string.IsNullOrEmpty(clientId))
                clientOperationsRepository.Save(clientId, operation);
            return result;
        }
    }
}
