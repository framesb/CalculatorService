using System.Collections.Generic;

namespace CalculatorService.Client.Operations
{
    public interface IOperation
    {
        string Key { get; }
        string Execute(List<string> arguments);
    }
}
