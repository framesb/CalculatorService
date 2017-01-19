using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CalculatorService.Domain.Entities;
using CalculatorService.Domain.UseCases;
using CalculatorService.Domain.UseCases.Abstractions;
using CalculatorService.JsonPersistence.Repositories;
using CalculatorService.Server.Models;
using Newtonsoft.Json;
using NLog;

namespace CalculatorService.Server.Controllers
{
    [RoutePrefix("journal")]
    public class JournalServiceController : ApiController
    {
        private Logger logger;
        private IGetJournalUseCase useCase;

        public JournalServiceController()
        {

            logger = LogManager.GetLogger(typeof(JournalServiceController).Name);
            string dataFolder = null;
            if (HttpContext.Current != null)
                dataFolder = HttpContext.Current.Server.MapPath("~/App_Data/");
            else
            {
                dataFolder = @"C:\CalculatorData";
                if (!Directory.Exists(dataFolder))
                    Directory.CreateDirectory(dataFolder);
            }
            useCase = new GetJournalUseCase(new ClientOperationsRepository(dataFolder));
        }

        //Constructor to use with Dependency Injection
        public JournalServiceController(IGetJournalUseCase useCase, Logger logger)
        {
            this.logger = logger;
            this.useCase = useCase;
        }

        [HttpPost]
        [Route("query")]
        public IHttpActionResult Query()
        {
            QueryOperation operation = null;
            try
            {
                QueryOperationDTO operationDTO = JsonConvert.DeserializeObject<QueryOperationDTO>(GetRequestContent(Request));
                operation = Mappers.QueryOperationMapper.Map(operationDTO);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return BadRequest(ex.Message);
            }
            try
            {
                var clientOperations = useCase.Execute(operation);
                return Ok(clientOperations);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return InternalServerError(ex);
            }
        }

        private void LogError(Exception ex)
        {
            logger.Error(string.Format("Error processing operation: {0} StackTrace: {1}", ex.Message, ex.StackTrace));
        }

        private string GetRequestContent(HttpRequestMessage request)
        {
            var content = request.Content.ReadAsStreamAsync().Result;
            StreamReader sr = new StreamReader(content);
            return sr.ReadToEnd();
        }
    }
}
