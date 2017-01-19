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
    [RoutePrefix("calculator")]
    public class CalculatorServiceController : ApiController
    {
        private Logger logger;
        private IProcessOperationUseCase useCase;

        public CalculatorServiceController()
        {
            logger = LogManager.GetLogger(typeof(CalculatorServiceController).Name);
            string dataFolder = null;
            if (HttpContext.Current != null)
                dataFolder = HttpContext.Current.Server.MapPath("~/App_Data/");
            else
            {
                dataFolder = @"C:\CalculatorData";
                if (!Directory.Exists(dataFolder))
                    Directory.CreateDirectory(dataFolder);
            }
                
            useCase = new ProcessOperationUseCase(new ClientOperationsRepository(dataFolder));
        }

        //Constructor to use with Dependency Injection
        public CalculatorServiceController(IProcessOperationUseCase useCase, Logger logger)
        {
            this.logger = logger;
            this.useCase = useCase;
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Sum()
        {
            IOperation operation = null;
            try
            {
                AddOperationDTO operationDTO = JsonConvert.DeserializeObject<AddOperationDTO>(GetRequestContent(Request));
                operation = Mappers.AddOperationMapper.Map(operationDTO);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return BadRequest(ex.Message);
            }
            return ProcessOperation(operation);
        }

        [HttpPost]
        [Route("sub")]
        public IHttpActionResult Sub()
        {
            IOperation operation = null;
            try
            {
                SubOperationDTO operationDTO = JsonConvert.DeserializeObject<SubOperationDTO>(GetRequestContent(Request));
                operation = Mappers.SubOperationMapper.Map(operationDTO);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return BadRequest(ex.Message);
            }
            return ProcessOperation(operation);
        }

        [HttpPost]
        [Route("mult")]
        public IHttpActionResult Mult()
        {
            IOperation operation = null;
            try
            {
                MultOperationDTO operationDTO = JsonConvert.DeserializeObject<MultOperationDTO>(GetRequestContent(Request));
                operation = Mappers.MultOperationMapper.Map(operationDTO);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return BadRequest(ex.Message);
            }
            return ProcessOperation(operation);
        }

        [HttpPost]
        [Route("div")]
        public IHttpActionResult Div()
        {
            IOperation operation = null;
            try
            {
                DivOperationDTO operationDTO = JsonConvert.DeserializeObject<DivOperationDTO>(GetRequestContent(Request));
                operation = Mappers.DivOperationMapper.Map(operationDTO);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return BadRequest(ex.Message);
            }
            return ProcessOperation(operation);
        }

        [HttpPost]
        [Route("sqrt")]
        public IHttpActionResult Sqrt()
        {
            IOperation operation = null;
            try
            {
                SqrtOperationDTO operationDTO = JsonConvert.DeserializeObject<SqrtOperationDTO>(GetRequestContent(Request));
                operation = Mappers.SqrtOperationMapper.Map(operationDTO);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return BadRequest(ex.Message);
            }
            return ProcessOperation(operation);
        }

        private IHttpActionResult ProcessOperation(IOperation operation)
        {
            try
            {
                var operationResult = Execute(operation);
                return Ok(operationResult);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return InternalServerError(ex);
            }
        }

        private IOperationResult Execute(IOperation operation)
        {
            var clientId = GetClientId();
            return useCase.Execute(operation, clientId);
        }

        private string GetClientId()
        {
            string clientId = null;
            IEnumerable<string> headerValue = null;
            if (Request.Headers.TryGetValues("X-Evi-Tracking-Id", out headerValue))
            {
                clientId = headerValue.First();
            }
            return clientId;
        }

        private string GetRequestContent(HttpRequestMessage request)
        {
            var content = request.Content.ReadAsStreamAsync().Result;
            StreamReader sr = new StreamReader(content);
            return sr.ReadToEnd();
        }

        private void LogError(Exception exception)
        {
            logger.Error(string.Format("Error processing operation: {0} StackTrace: {1}", exception.Message, exception.StackTrace));
        }
    }
}
