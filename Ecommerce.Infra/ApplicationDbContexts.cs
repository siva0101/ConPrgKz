using Ecommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infra
{
    public class ApplicationDbContexts : DbContext
    {
        public ApplicationDbContexts(DbContextOptions<ApplicationDbContexts> options) : base(options) 
        { 
        }
        public DbSet<Products> ProductsDb { get; set; }
        public DbSet<Category> CategoriesDb { get; set; }
        public DbSet<Variation> VariationDb { get; set; }
        public DbSet<Size_Stocks> Size_StocksDb { get; set; }
        public DbSet<Images> ImageDb { get; set; }
        public DbSet<Brand> BrandDb { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Variation>().HasOne(a=>a.Products)
                .WithMany(b=>b.Variations).HasForeignKey(c=>c.ProductId);
            modelBuilder.Entity<Size_Stocks>().HasOne(b => b.Variation)
                .WithMany(a => a.Size).HasForeignKey(c => c.VariationId);
            
        }


    }
}
