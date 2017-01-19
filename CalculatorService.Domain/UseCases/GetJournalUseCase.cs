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
    public class GetJournalUseCase : IGetJournalUseCase
    {
        IClientOperationsRepository clientOperationsRepository;

        public GetJournalUseCase(IClientOperationsRepository clientOperationsRepository)
        {
            this.clientOperationsRepository = clientOperationsRepository;
        }

        public ClientOperations Execute(QueryOperation queryOperation)
        {
            ClientOperations result = null;
            if (!string.IsNullOrEmpty(queryOperation.ClientId))
                result = clientOperationsRepository.GetOperations(queryOperation.ClientId);
            return result;
        }
    }
}
