using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CalculatorService.Client.Operations;

namespace CalculatorService.Client
{
    public class OperationFactory​
    {
        static List<IOperation> operations = null;

        static OperationFactory​()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(mytype =>
                mytype.GetInterfaces().Contains(typeof (IOperation)));

            operations = new List<IOperation>();

            foreach (Type type in types)
            {
                operations.Add((IOperation)Activator.CreateInstance(type));
            }
        }

        public static IOperation GetOperation(string key)
        {
            IOperation operation = operations.FirstOrDefault(x=>x.Key.ToLowerInvariant().Equals(key.ToLowerInvariant()));
            return operation;
        }
    }
}
