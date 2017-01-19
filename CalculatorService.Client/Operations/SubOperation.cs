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
    public class SubOperation : IOperation
    {
        public string Key
        {
            get { return "sub"; }
        }

        public string Execute(List<string> arguments)
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                SubOperationDTO operationInput = null;
                if (arguments.Count == 2)
                {
                    client.Headers.Add(ConfigSettings.ClientHeader, arguments[0].ToLowerInvariant());
                    operationInput = ExtractOperationInput(arguments[1]);
                }
                else
                    operationInput = ExtractOperationInput(arguments[0]);
                return client.UploadString(string.Format("{0}calculator/sub", ConfigSettings.BaseUrl), "POST", JsonConvert.SerializeObject(operationInput));
            }
        }

        private SubOperationDTO ExtractOperationInput(string argument)
        {
            var arguments = argument.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).ToList();

            return new SubOperationDTO() {Minuend = int.Parse(arguments[0]), Subtrahend = int.Parse(arguments[1])};
        }
    }
}