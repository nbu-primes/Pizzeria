using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pizzeria.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pizzeria.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Additive> Additives { get; set; }
        public DbSet<Caterer> Caterers { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderHistory> OrderHistory { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //many to many  config 
            // https://www.learnentityframeworkcore.com/configuration/many-to-many-relationship-configuration

            modelBuilder.Entity<OrderAdditive>()
                .HasKey(m => new { m.OrderId, m.AdditiveId });
            modelBuilder.Entity<OrderAdditive>()
                .HasOne(oa => oa.Additive)
                .WithMany(a => a.OrderAdditives)
                .HasForeignKey(a => a.AdditiveId);
            modelBuilder.Entity<OrderAdditive>()
                .HasOne(oa => oa.Order)
                .WithMany(o => o.OrderAdditives)
                .HasForeignKey(o => o.OrderId);

            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(m => new { m.IngredientId, m.RecipeId });
            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(r => r.RecipeId);
            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(i => i.IngredientId);

            // one to one
            modelBuilder.Entity<Order>()
               .HasOne(o => o.OrderHistory)
               .WithOne(h => h.Order)
               .HasForeignKey<OrderHistory>(h => h.OrderId);

            modelBuilder.SeedRecipes();

            base.OnModelCreating(modelBuilder);
        }
    }
}
