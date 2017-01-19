using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CalculatorService.Server.Controllers;
using CalculatorService.Server.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace CalculatorService.Server.Tests.Controllers
{
    [TestClass]
    public class CalculatorServiceControllerTests : WebApiClassBase, IDisposable
    {
        static string apiUrl = "/calculator/";
        static string clientHeader = "X-Evi-Tracking-Id";
        public CalculatorServiceControllerTests() : base("localhost", 8080, typeof(CalculatorServiceController))
        {
            base.Start();
        }

        public new void Dispose()
        {
            base.Close();
            base.Dispose();
        }

        [TestMethod]
        public void When_InvalidInput_Then_BadRequest()
        {
            Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject("asdasd")));
            var data = new StreamContent(stream);
            var response = base.CreateRequest(apiUrl + "add", HttpMethod.Post, null, null,  data);
            Assert.IsNotNull(response);
            Assert.IsTrue(response.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void When_ValidInput_Then_OkResult()
        {
            Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new AddOperationDTO() { Addends = new List<int>() { 2, 3, 5 } })));
            var data = new StreamContent(stream);
            var response = base.CreateRequest(apiUrl + "add", HttpMethod.Post, null, null, data);
            Assert.IsNotNull(response);
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public void When_InputWithClientId_Then_OkResult()
        {
            Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new AddOperationDTO() { Addends = new List<int>() { 2, 3, 5 } })));
            var data = new StreamContent(stream);
            var response = base.CreateRequest(apiUrl + "add", HttpMethod.Post, clientHeader, "client_1", data);
            Assert.IsNotNull(response);
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }
    }
}
