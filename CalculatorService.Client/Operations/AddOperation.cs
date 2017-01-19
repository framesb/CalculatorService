using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CalculatorService.Server.Models;
using Newtonsoft.Json;

namespace CalculatorService.Client.Operations
{
    public class AddOperation : IOperation
    {
        public string Key { get { return "add"; } }

        public string Execute(List<string> arguments)
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                AddOperationDTO operationInput = null;
                if (arguments.Count == 2)
                {
                    client.Headers.Add(ConfigSettings.ClientHeader, arguments[0].ToLowerInvariant());
                    operationInput = ExtractOperationInput(arguments[1]);
                }
                else
                    operationInput = ExtractOperationInput(arguments[0]);
                return client.UploadString(string.Format("{0}calculator/add", ConfigSettings.BaseUrl), "POST", JsonConvert.SerializeObject(operationInput));
            }
        }

        private AddOperationDTO ExtractOperationInput(string argument)
        {
            var addends = new List<int>();
            argument.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(x => addends.Add(int.Parse(x)));
            return new AddOperationDTO() {Addends = addends};
        }
    }
}
