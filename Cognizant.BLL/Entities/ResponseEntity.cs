using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.BLL.Entities
{
    public class ResponseEntity
    {
        [JsonProperty("output")]
        public string Output { get; set; }
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }
        [JsonProperty("memory")]
        public string Memory { get; set; }
        [JsonProperty("cpuTime")]
        public string CpuTime { get; set; }
    }
}
