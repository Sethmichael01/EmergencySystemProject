using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyApplication.Models
{
    public class HttpResponseModel
    {
        [JsonProperty("status")]
        public int StatusCode { get; set; }
        [JsonProperty("errors")]
        public object ErrorMessage { get; set; }
        public string Data { get; set; }
       
        
    }
}
