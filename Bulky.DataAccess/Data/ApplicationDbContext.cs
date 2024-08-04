
using Microsoft.EntityFrameworkCore;
using Bulky.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
             
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "Book 1", Description="test description 1",ISBN="00001",Author="test author 1",ListPrice=500,Price=450,Price50=425,Price100=400,ImageUrl="", CategoryId = 1 },
                new Product { Id = 2, Title = "Book 2", Description="test description 2",ISBN="00002",Author="test author 2",ListPrice=600,Price=550,Price50=525,Price100=500, ImageUrl = "", CategoryId = 1 },
                new Product { Id = 3, Title = "Book 3", Description="test description 3",ISBN="00003",Author="test author 3",ListPrice=700,Price=650,Price50=625,Price100=600, ImageUrl = "", CategoryId = 2 }
                
                );
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Tech Solutions", StreetAddress = "123 Main Street", City = "Colombo", PostalCode = "80200", State = "West", PhoneNumber = "0112222222" },
                new Company { Id = 2, Name = "Vivid Books", StreetAddress = "Dunkley Street", City = "Galle", PostalCode = "80300", State = "South", PhoneNumber = "0912342223" },
                new Company { Id = 3, Name = "Readers Club", StreetAddress = "258 Main Street", City = "Colombo", PostalCode = "80200", State = "West", PhoneNumber = "0112333333" }
                

                );
        }
    }
}
