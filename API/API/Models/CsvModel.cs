using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class CsvModel
    {
        [JsonIgnore]
        public int Id { get; set;  }
        public string Parent { get; set; }
        public string Child { get; set; }
        public int Quantity { get; set; }
    }
}
