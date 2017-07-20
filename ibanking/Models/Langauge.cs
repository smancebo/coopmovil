using System;
namespace ibanking.Models
{
    public class Langauge
    {
        public string id { get; set; }
        public string description { get; set; }
        public Langauge()
        {
            this.id = "";
            this.description = "";
        }
    }
}
