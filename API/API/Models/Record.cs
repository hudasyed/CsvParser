using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Record
    {
        public string Parent { get; set; }
        public string Child { get; set; }
        public int Quantity { get; set; }
    }
}
