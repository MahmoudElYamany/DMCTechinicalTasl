using Microsoft.EntityFrameworkCore;
using System;
using Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Context
{
    public class ApiContext : IdentityDbContext<Customer>
    {
        public DbSet<Category> categories { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<orderDetial> orderDetials { get; set; }
        public DbSet<orderHeader> orderHeaders { get; set; }
        public DbSet<orderHeaderCustomer> headerCustomers { get; set; }
        public DbSet<Status> statuses { get; set; }
        public DbSet<UOM> UOMs { get; set; }
        
        public ApiContext(DbContextOptions options) : base(options) { }

        
    }
    
}
