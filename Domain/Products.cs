using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
    public class Products 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Price { get; set; }
        public int UserId { get; set; }

        public Products(string name, string link, string price)
        {
            Name = name;
            Link = link;
            Price = price;
            
        }

        public Products()
        {
        }
    }
}
