using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CalculatorService.Client.Operations;
using CalculatorService.Server.Models;
using Newtonsoft.Json;

namespace CalculatorService.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Calculator Service***");
            Console.WriteLine("***Usage: operation clientId(optional) params");
            Console.WriteLine("***Examples:");
            Console.WriteLine("***add client2 2,3,5");
            Console.WriteLine("***sub 7,-4");
            Console.WriteLine("***mult client1 3,2,8");
            Console.WriteLine("***div 8,3");
            Console.WriteLine("***sqrt client2 16");
            Console.WriteLine("***id client2");
            Console.WriteLine("************************");
            while (true)
            {
                string command = Console.ReadLine();
                try
                {
                    var commandArgs = command.Split(new[] { ' ' }).ToList();
                    IOperation operation = OperationFactory​.GetOperation(commandArgs[0]); ;
                    
                    commandArgs.RemoveAt(0);
                    var result = operation.Execute(commandArgs);
                    Console.WriteLine("Operation result: " + result);
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Operation error: " + ex.Message);
                }
            }


            //using (var client = new WebClient())
            //{
            //    client.Headers[HttpRequestHeader.ContentType] = "application/json";
            //    //Client1
            //    client.Headers.Add("X-Evi-Tracking-Id", "Client1");
            //    Console.WriteLine("Client 1 Sends Add operation with Addends 1,2,3");
            //    result = client.UploadString("http://localhost:3679/calculator/add", "POST", JsonConvert.SerializeObject(new AddOperationDTO() {Addends = new List<int>() { 1, 2, 3 } }));
            //    Console.WriteLine("Operation result: "+result);
            //    Console.WriteLine();
            //    Console.WriteLine("Client 1 Sends Add operation with Addends 5,4");
            //    result = client.UploadString("http://localhost:3679/calculator/add", "POST", JsonConvert.SerializeObject(new AddOperationDTO() { Addends = new List<int>() { 5, 4 } }));
            //    Console.WriteLine("Operation result: " + result);
            //    Console.WriteLine();
            //    Console.WriteLine("Client 1 Sends Sub operation with Minuend 3, Subtrahend -7");
            //    result = client.UploadString("http://localhost:3679/calculator/sub", "POST", JsonConvert.SerializeObject(new SubOperationDTO() {Minuend = 3, Subtrahend = -7}));
            //    Console.WriteLine("Operation result: " + result);
            //    Console.WriteLine();
            //    //Client2
            //    client.Headers["X-Evi-Tracking-Id"] = "Client2";
            //    Console.WriteLine("Client 2 Sends Mult operation with Factors 5,4");
            //    result = client.UploadString("http://localhost:3679/calculator/mult", "POST", JsonConvert.SerializeObject(new MultOperationDTO() { Factors = new List<int>() { 5, 4 }}));
            //    Console.WriteLine("Operation result: " + result);
            //    Console.WriteLine();
            //    Console.WriteLine("Client 2 Sends Div operation with Dividend 7, Divisor 3");
            //    result = client.UploadString("http://localhost:3679/calculator/div", "POST", JsonConvert.SerializeObject(new DivOperationDTO() { Dividend = 7, Divisor = 3 }));
            //    Console.WriteLine("Operation result: " + result);
            //    Console.WriteLine();
            //    Console.WriteLine("Client 2 Sends Sqrt operation with Number 15");
            //    result = client.UploadString("http://localhost:3679/calculator/sqrt", "POST", JsonConvert.SerializeObject(new SqrtOperationDTO() { Number = 15}));
            //    Console.WriteLine("Operation result: " + result);
            //    Console.WriteLine();
            //    //Anonymous client
            //    client.Headers.Remove("X-Evi-Tracking-Id");
            //    Console.WriteLine("Anomynous client Sends Mult operation with Factors 4,3,2");
            //    result = client.UploadString("http://localhost:3679/calculator/mult", "POST", JsonConvert.SerializeObject(new MultOperationDTO() { Factors = new List<int>() { 4, 3, 2 } }));
            //    Console.WriteLine("Operation result: " + result);
            //    Console.WriteLine();
            //    Console.WriteLine("Anomynous client Sends Div operation with Dividend 12, Divisor 5");
            //    result = client.UploadString("http://localhost:3679/calculator/div", "POST", JsonConvert.SerializeObject(new DivOperationDTO() { Dividend = 12, Divisor = 5 }));
            //    Console.WriteLine("Operation result: " + result);
            //    Console.WriteLine();
            //}
            //Console.ReadLine();
        }

        public static string HttpGet(string URI)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }
        public static string HttpPost(string URI, string Parameters)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            //Add these, as we're doing a POST
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            //We need to count how many bytes we're sending. Post'ed Faked Forms should be name=value&
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(Parameters);
            req.ContentLength = bytes.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length); //Push it out there
            os.Close();
            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }
    }
}
