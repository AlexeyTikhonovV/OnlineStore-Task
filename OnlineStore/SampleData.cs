using OnlineStore.Models;
using System.Linq;

namespace OnlineStore
{
    public static class SampleData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Commodity.Any())
            {
                context.Commodity.AddRange(
                    new Goods
                    {
                        Name = "iPhone 6S",
                        Price = 600,
                        Category = "Phone",
                        Image = "Goods/iPhone 6S.png"
                    },
                    new Goods
                    {
                        Name = "Samsung Galaxy s6 Edge",
                        Price = 550,
                        Category = "Phone",
                        Image = "Goods/Samsung Galaxy s6 Edge.png"
                    },
                    new Goods
                    {
                        Name = "Lumia 950",
                        Price = 500,
                        Category = "Phone",
                        Image = "Goods/Lumia 950.png"
                    },
                    new Goods
                    {
                        Name = "EZBook X4 Pro",
                        Price = 500,
                        Category = "Laptops",
                        Image = "Goods/EZBook X4 Pro.png"
                    },
                    new Goods
                    {
                        Name = "Teclast F7",
                        Price = 400,
                        Category = "Laptops",
                        Image = "Goods/Teclast F7.png"
                    },
                    new Goods
                    {
                        Name = "Microsoft Surface Go",
                        Price = 600,
                        Category = "Laptops",
                        Image = "Goods/Microsoft Surface Go.png"
                    },
                    new Goods
                    {
                        Name = "GPD Pocket2",
                        Price = 560,
                        Category = "Laptops",
                        Image = "Goods/GPD Pocket2.png"
                    },
                    new Goods
                    {
                        Name = "ALLDOCUBE iWork10 Pro",
                        Price = 250,
                        Category = "Laptops",
                        Image = "Goods/ALLDOCUBE iWork10 Pro.png"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
