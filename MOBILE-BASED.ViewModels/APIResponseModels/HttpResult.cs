using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOBILE_BASED.ViewModels.APIResponseModels
{
    public class HttpResult
    {
        [JsonProperty("status")]
        public int Status { get; set; }
        public string Data { get; set; }
    }
}
