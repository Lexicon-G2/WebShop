using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAppForWebshop.Controllers
{
    public class ShoppingCartController1 : Controller
    {   
        //get shopping Cart
        public IActionResult Index()
        {
            return View();
        }
    }
}
