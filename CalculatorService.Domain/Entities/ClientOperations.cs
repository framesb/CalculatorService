using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Domain.Entities
{
    public class ClientOperations
    {
        public List<IOperation> Operations { get; set; }

        public ClientOperations()
        {
            Operations = new List<IOperation>();
        }
    }
}
