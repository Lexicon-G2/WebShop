using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebAppForWebshop.Models
{
    public class CartItem
    {
        //public List <Products> Product { get; set; }

        //public int Quantity { get; set; }


        //public CartItem(List<Products>  product, int quantity)
        //{
        //    Product = product;
        //    Quantity = quantity;
        //}


        [Key]
        public string ItemId { get; set; }

        public string CartId { get; set; }

        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; }

        public int ProductId { get; set; }

        public virtual Products Product { get; set; }
    }
}
    