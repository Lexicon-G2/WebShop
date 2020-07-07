using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppForWebshop.Data;
using WebAppForWebshop.Models;

namespace WebAppForWebshop.Controllers
{
    public class ShoppingCartController1 : Controller
    {

        public string ShoppingCartId { get; set; }

        private ApplicationDbContext _db = new ApplicationDbContext();

        public const string CartSessionKey = "CartId";

        private readonly IHttpContextAccessor _httpContextAccessor;
 

 
public ShoppingCartController1(IHttpContextAccessor httpContextAccessor)            
        {
            _httpContextAccessor = httpContextAccessor;
        }

        //get shopping Cart
        public IActionResult Index()
        {

            return View();
        }



        public IActionResult AddToCart(int id)
        {
            // Retrieve the product from the database. 
            ShoppingCartId = GetCartId();

            var cartItem = _db.ShoppingCartItems.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.ProductId == id);
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists.                 
                cartItem = new CartItem
                {
                    ItemId = Guid.NewGuid().ToString(),
                    ProductId = id,
                    CartId = ShoppingCartId,
                    Product = _db.Products.SingleOrDefault(
                   p => p.ProductID == id),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                _db.ShoppingCartItems.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart,                  
                // then add one to the quantity.                 
                cartItem.Quantity++;
            }
            _db.SaveChanges();

            return View();
        }

       
        public string GetCartId()
        {
            
            if (HttpContext.Session.GetString("CartSessionKey") == null)
            {
                if (!string.IsNullOrWhiteSpace(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value))
                {
                    HttpContext.Session.SetString("CartSessionKey",_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Session.SetString("CartSessionKey", tempCartId.ToString());
                }
            }
            return HttpContext.Session.GetString("CartSessionKey").ToString();
        }

        public List<CartItem> GetCartItems()
        {
            ShoppingCartId = GetCartId();

            return _db.ShoppingCartItems.Where(
                c => c.CartId == ShoppingCartId).ToList();
        }
    }
}
