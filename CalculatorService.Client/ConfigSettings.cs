using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Client
{
    public static class ConfigSettings
    {
        public static readonly string BaseUrl = "http://localhost:3679/";
        public static readonly string ClientHeader = "X-Evi-Tracking-Id";
    }
}
