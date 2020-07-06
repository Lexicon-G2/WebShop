using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppForWebshop.Models;


namespace WebAppForWebshop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public ApplicationDbContext()
            : base()
        {
        }


        public DbSet<Products> Products { get; set; }
        //public DbSet<Customers> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }


        DbSet<ApplicationUser> Users { get; set; }


        public DbSet<CartItem> ShoppingCartItems { get; set; }


    }
}
