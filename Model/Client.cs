using ShopDatabaseAdvanced.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDatabaseAdvanced.Model
{
    public class Client
    {
       

        public Guid Id { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }


        public Client(string firstname, string lastname)
        {
            Id = Guid.NewGuid();
            FirstName = firstname;
            LastName = lastname;
            ShoppingCarts = new List<ShoppingCart>();
        }

        public Client()
        {
        }

      
    }
}
