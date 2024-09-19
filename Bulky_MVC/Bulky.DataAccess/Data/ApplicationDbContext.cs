using FashionFinds.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FashionFinds.DataAcess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser> 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Men’s Clothing", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Women’s Clothing", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Kid’s Clothing", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Unisex Clothing", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Accessories", DisplayOrder = 5 }
                );

            modelBuilder.Entity<Company>().HasData(
               
                new Company
                {
                    Id = 1,
                    Name = "Urban Outfitters",
                    StreetAddress = "101 Urban Ave",
                    City = "Metropolis",
                    PostalCode = "10001",
                    State = "NY",
                    PhoneNumber = "2125551234"
                },
new Company
{
    Id = 2,
    Name = "Fashion Fusion",
    StreetAddress = "202 Fashion Blvd",
    City = "Style City",
    PostalCode = "20002",
    State = "CA",
    PhoneNumber = "3105555678"
},
new Company
{
    Id = 3,
    Name = "Trendy Threads",
    StreetAddress = "303 Trendy Rd",
    City = "Chic Town",
    PostalCode = "30003",
    State = "TX",
    PhoneNumber = "5125559876"
},
new Company
{
    Id = 4,
    Name = "Elegant Attire",
    StreetAddress = "404 Elegant Ln",
    City = "Sophia",
    PostalCode = "40004",
    State = "FL",
    PhoneNumber = "5615554567"
},
new Company
{
    Id = 5,
    Name = "Classic Styles",
    StreetAddress = "505 Classic St",
    City = "Vintage Ville",
    PostalCode = "50005",
    State = "WA",
    PhoneNumber = "2065556789"
},
new Company
{
    Id = 6,
    Name = "Modern Wardrobe",
    StreetAddress = "606 Modern Dr",
    City = "Contemporary City",
    PostalCode = "60006",
    State = "OR",
    PhoneNumber = "5035552345"
},
new Company
{
    Id = 7,
    Name = "Chic Couture",
    StreetAddress = "707 Chic Ave",
    City = "Glamour Town",
    PostalCode = "70007",
    State = "IL",
    PhoneNumber = "7085553456"
},
new Company
{
    Id = 8,
    Name = "Style Haven",
    StreetAddress = "808 Style St",
    City = "Fashionburg",
    PostalCode = "80008",
    State = "NJ",
    PhoneNumber = "2015556789"
},
new Company
{
    Id = 9,
    Name = "Vogue Vision",
    StreetAddress = "909 Vogue Blvd",
    City = "Elite City",
    PostalCode = "90009",
    State = "GA",
    PhoneNumber = "4045551234"
},
new Company
{
    Id = 10,
    Name = "Supreme Threads",
    StreetAddress = "1010 Supreme Ln",
    City = "Trendsetters",
    PostalCode = "10101",
    State = "CO",
    PhoneNumber = "7205554321"
}


                );


            modelBuilder.Entity<Product>().HasData(
               new Product
                    {
                        Id = 1,
                        Title = "Urban Chic Jacket",
                        Brand = "Urban Wear",
                        Description = "A stylish and comfortable jacket perfect for urban environments. Made with high-quality materials for durability.",
                        ListPrice = 120,
                        Price = 100,
                        Price50 = 90,
                        Price100 = 85,
                        CategoryId = 1
                    },
new Product
{
    Id = 2,
    Title = "Classic Denim Jeans",
    Brand = "Classic Fit",
    Description = "Timeless denim jeans with a perfect fit. Ideal for everyday wear.",
    ListPrice = 80,
    Price = 70,
    Price50 = 65,
    Price100 = 60,
    CategoryId = 1
},
new Product
{
    Id = 3,
    Title = "Vanish in the Sunset",
    Brand = "Julian Button",
    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt.",
    ListPrice = 55,
    Price = 50,
    Price50 = 40,
    Price100 = 35,
    CategoryId = 1
},
new Product
{
    Id = 4,
    Title = "Cotton Candy",
    Brand = "Abby Muscles",
    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt.",
    ListPrice = 70,
    Price = 65,
    Price50 = 60,
    Price100 = 55,
    CategoryId = 2
},
new Product
{
    Id = 5,
    Title = "Elegant Evening Gown",
    Brand = "Glamour Couture",
    Description = "An elegant evening gown perfect for special occasions. Crafted with exquisite fabric for a sophisticated look.",
    ListPrice = 200,
    Price = 180,
    Price50 = 170,
    Price100 = 160,
    CategoryId = 2
},
new Product
{
    Id = 6,
    Title = "Casual Polo Shirt",
    Brand = "Comfort Wear",
    Description = "A casual polo shirt suitable for various occasions. Soft fabric for ultimate comfort.",
    ListPrice = 50,
    Price = 45,
    Price50 = 40,
    Price100 = 35,
    CategoryId = 1
},
new Product
{
    Id = 7,
    Title = "Sporty Tracksuit",
    Brand = "Active Gear",
    Description = "A tracksuit designed for active individuals. Lightweight and breathable material for enhanced performance.",
    ListPrice = 90,
    Price = 80,
    Price50 = 75,
    Price100 = 70,
    CategoryId = 3
},
new Product
{
    Id = 8,
    Title = "Vintage Leather Boots",
    Brand = "Heritage Footwear",
    Description = "High-quality leather boots with a vintage design. Durable and stylish for everyday wear.",
    ListPrice = 150,
    Price = 140,
    Price50 = 130,
    Price100 = 120,
    CategoryId = 4
},
new Product
{
    Id = 9,
    Title = "Summer Floral Dress",
    Brand = "Sunny Styles",
    Description = "A beautiful floral dress ideal for summer outings. Made with lightweight fabric for a breezy feel.",
    ListPrice = 75,
    Price = 65,
    Price50 = 60,
    Price100 = 55,
    CategoryId = 2
},
new Product
{
    Id = 10,
    Title = "Winter Wool Sweater",
    Brand = "Warmwear",
    Description = "A cozy wool sweater perfect for winter. Provides warmth and comfort during chilly weather.",
    ListPrice = 110,
    Price = 100,
    Price50 = 90,
    Price100 = 85,
    CategoryId = 1
},
new Product
{
    Id = 11,
    Title = "Boho Chic Maxi Skirt",
    Brand = "Boho Trends",
    Description = "A trendy maxi skirt with a bohemian design. Flowy and comfortable for a relaxed look.",
    ListPrice = 60,
    Price = 55,
    Price50 = 50,
    Price100 = 45,
    CategoryId = 2
},
new Product
{
    Id = 12,
    Title = "Formal Dress Shirt",
    Brand = "Business Elite",
    Description = "A crisp and formal dress shirt for professional settings. Made with high-quality cotton for a refined appearance.",
    ListPrice = 65,
    Price = 60,
    Price50 = 55,
    Price100 = 50,
    CategoryId = 1
},
new Product
{
    Id = 13,
    Title = "Denim Jacket",
    Brand = "Denim Co.",
    Description = "A classic denim jacket with a modern fit. Versatile and stylish for various outfits.",
    ListPrice = 85,
    Price = 75,
    Price50 = 70,
    Price100 = 65,
    CategoryId = 1
},
new Product
{
    Id = 14,
    Title = "Leather Crossbody Bag",
    Brand = "Luxury Bags",
    Description = "A chic leather crossbody bag perfect for daily use. Spacious and stylish for all your essentials.",
    ListPrice = 120,
    Price = 110,
    Price50 = 105,
    Price100 = 100,
    CategoryId = 4
},
new Product
{
    Id = 15,
    Title = "Graphic Tee",
    Brand = "Trendsetters",
    Description = "A fun graphic tee that adds a touch of personality to your wardrobe. Made with comfortable cotton fabric.",
    ListPrice = 40,
    Price = 35,
    Price50 = 30,
    Price100 = 25,
    CategoryId = 1
},
new Product
{
    Id = 16,
    Title = "High-Waisted Shorts",
    Brand = "Summer Vibes",
    Description = "Stylish high-waisted shorts ideal for summer. Comfortable and breathable for hot days.",
    ListPrice = 50,
    Price = 45,
    Price50 = 40,
    Price100 = 35,
    CategoryId = 2
},
new Product
{
    Id = 17,
    Title = "Puffer Vest",
    Brand = "Outdoor Gear",
    Description = "A practical puffer vest for outdoor activities. Provides warmth without bulk, perfect for layering.",
    ListPrice = 100,
    Price = 90,
    Price50 = 85,
    Price100 = 80,
    CategoryId = 3
},
new Product
{
    Id = 18,
    Title = "Silk Scarf",
    Brand = "Elegant Accessories",
    Description = "A luxurious silk scarf that adds a touch of elegance to any outfit. Soft and versatile for multiple styling options.",
    ListPrice = 45,
    Price = 40,
    Price50 = 35,
    Price100 = 30,
    CategoryId = 4
},
new Product
{
    Id = 19,
    Title = "Striped Beachwear",
    Brand = "Beachy Keen",
    Description = "Bright and colorful beachwear with a striped pattern. Ideal for fun days by the sea.",
    ListPrice = 55,
    Price = 50,
    Price50 = 45,
    Price100 = 40,
    CategoryId = 2
},
new Product
{
    Id = 20,
    Title = "Smart Casual Blazer",
    Brand = "Urban Elite",
    Description = "A sleek smart casual blazer suitable for various occasions. Made with premium fabric for a refined look.",
    ListPrice = 140,
    Price = 130,
    Price50 = 120,
    Price100 = 110,
    CategoryId = 1
}









                );
        }
    }
}
