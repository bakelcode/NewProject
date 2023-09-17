using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsProject.Shared.Models;

namespace NewsProject.Server.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                CategoryName = "الالمواد الغذائية"

            });
            builder.Entity<Category>().HasData(new Category
            {
                Id = 2,
                CategoryName = "المستلزمات"

            });
            builder.Entity<Category>().HasData(new Category
            {
                Id = 3,
                CategoryName = "الكمبيوتر"

            });
            builder.Entity<Barench>().HasData(new Barench
            {
                BarenchID = 1,
                BarenchName = "فرع تعز"

            });
            builder.Entity<Barench>().HasData(new Barench
            {
                BarenchID = 2,
                BarenchName = "فرع صنعاء "

            });
            builder.Entity<Product>().HasData(new Product
            {
                CategoryId = 1,
                ProductName = " حليب",
                BarenchID = 1,
                Price = 200,
                Quntity = 20,
                ProductID = 1,
                CreatDate = DateTime.Now


            });
            builder.Entity<Product>().HasData(new Product
            {
                CategoryId = 2,
                ProductName = " اسسوارات  ",
                BarenchID = 1,
                Price = 4300,
                Quntity = 30,
                ProductID = 2,
                CreatDate = DateTime.Now


            });
            builder.Entity<Product>().HasData(new Product
            {
                CategoryId = 3,
                ProductName = " كمبيوتر ",
                BarenchID = 2,
                Price = 1600,
                Quntity = 200,
                ProductID = 3,
                CreatDate = DateTime.Now


            });
            builder.Entity<Product>().HasData(new Product
            {
                CategoryId = 1,
                ProductName = " دقيق",
                BarenchID = 1,
                Price = 20,
                Quntity = 30,
                ProductID = 4,
                CreatDate = DateTime.Now



            });
            builder.Entity<Supplier>().HasData(new Supplier
            {
                SupplierID = 1,
                SupplierName = "Bakel Asharabe",
                Phon = "771966828",
                BarenchID = 1,
                Emil = "bakel@gmail.com",
                Addrees = "Taiz",
                CreatDate = DateTime.Now

            });
            builder.Entity<Supplier>().HasData(new Supplier
            {
                BarenchID = 1,
                SupplierID = 2,
                SupplierName = "Mohmmed Asharabe",
                Phon = "771966828",
                Emil = "mog@gmail.com",
                Addrees = "Taiz",
                CreatDate = DateTime.Now


            });
            builder.Entity<Supplier>().HasData(new Supplier
            {
                BarenchID = 1,
                SupplierID = 3,
                SupplierName = " Asharabe",
                Phon = "771966828",
                Emil = "bak@eail.com",
                Addrees = "Taiz",
                CreatDate = DateTime.Now

            });
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                UserName = "bakel",
                Email = "bakel@gmail.com",
                PhoneNumber = "771966828",
                UserRoles = "Admin",
                PasswordHash = "AQAAAAEAACcQAAAAEAaowgzOkmmNXOX06rTW73waTEU1BPwc4B0fBVNCCw3vbo9dpF2aQ9E5QZBSK4nN1g==",
                Country = "Yemen"


            });


        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Barench> Barenches { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<InvoiceTemp> InvoiceTemps { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Invoicelist> Invoicelists { get; set; }
    }
}
