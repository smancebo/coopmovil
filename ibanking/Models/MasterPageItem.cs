using System;
namespace ibanking.Models
{
    public class MasterPageItem
    {

        public string Title { get; set; }
        public string Icon { get; set; }
        public Type TargetType { get; set; }
        public string frgType { get; set; }

        public MasterPageItem()
        {
            this.frgType = "";            
        }
    }
}
