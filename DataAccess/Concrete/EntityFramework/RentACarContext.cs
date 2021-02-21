using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public  class RentACarContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = Baycu;Database=RentACar; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }
        
        public DbSet<Car> Cars { get; set; }
        public DbSet<Entities.Concrete.Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        
    }
}
