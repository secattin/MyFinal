using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.concrete.EntityFramawork
{
    // Context: DB tabloları ile proje classlarını bağlamak
    // DbContext: EntityFramework
    // Nuget: Microsoft.EntityFrameworkCore
    // Nuget: Microsoft.EntityFrameworkCore.SqlServer
    // Nuget: Microsoft.EntityFrameworkCore.Tools

    public class NorthwindeContex:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-DE1PTH4\SQLEXPRESS;Database=Northwind;Trusted_Connection=true");
        }
        // ef daldan sonra gel buraya
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet <Order> orders { get; set; }
    }
}
