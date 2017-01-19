using System;
using System.IO;
using CalculatorService.Domain.Adapters.Data;
using CalculatorService.Domain.Entities;
using Newtonsoft.Json;

namespace CalculatorService.JsonPersistence.Repositories
{
    public class ClientOperationsRepository: IClientOperationsRepository
    {
        private string basePath;

        public ClientOperationsRepository(string basePath)
        {
            if(string.IsNullOrEmpty(basePath))
                throw new ArgumentNullException(nameof(basePath));
            this.basePath = basePath;
            if (!Directory.Exists(basePath))
                Directory.CreateDirectory(basePath);
        }
        public ClientOperations GetOperations(string clientId)
        {
            ClientOperations result = null;
            var clientFile = Path.Combine(basePath, clientId + ".json");
            if (File.Exists(clientFile))
            {
                result = JsonConvert.DeserializeObject<ClientOperations>(File.ReadAllText(clientFile), new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            return result;
        }

        public void Save(string clientId, IOperation operation)
        {
            ClientOperations operations = new ClientOperations();
            var clientFile = Path.Combine(basePath, clientId + ".json");
            if (File.Exists(clientFile))
            {
                operations = JsonConvert.DeserializeObject<ClientOperations>(File.ReadAllText(clientFile), new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            operations.Operations.Add(operation);
            File.WriteAllText(clientFile, JsonConvert.SerializeObject(operations, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore
            }));
        }
    }

}
