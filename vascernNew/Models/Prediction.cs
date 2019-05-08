using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vascernNew.Models
{
    public class Prediction
    {
        public string description { get; set; }
        public string id { get; set; }
        public string place_id { get; set; }
        public string reference { get; set; }
        public List<string> types { get; set; }
    }

    public class RootObject
    {
        public List<Prediction> predictions { get; set; }
        public string status { get; set; }
    }
}
