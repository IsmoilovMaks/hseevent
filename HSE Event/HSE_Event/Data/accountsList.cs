using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSE_Event.Data
{
    public class accountsList
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "login")]
        public string login { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string password { get; set; }
    }
}
