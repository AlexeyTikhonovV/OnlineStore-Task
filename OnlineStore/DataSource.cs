using OnlineStore.Models;
using System.Collections.Generic;

namespace OnlineStore
{
    public static class DataSource
    {
        private static IList<Goods> _goods { get; set; } 

        public static IList<Goods> GetGoods()
        {
            if (_goods != null)
            {
                return _goods;
            }

            _goods = new List<Goods>();

            Goods goods = new Goods
            {
                Id = 1,
                Name = "iPhone 6S",
                Price = 600,
                Category = "Phone",
                Image = "Goods/iPhone 6S.png"
            };
            _goods.Add(goods);

            goods = new Goods
            {
                Id = 2,
                Name = "Samsung Galaxy s6 Edge",
                Price = 550,
                Category = "Phone",
                Image = "Goods/Samsung Galaxy s6 Edge.png"
            };
            _goods.Add(goods);

            return _goods;
        }
    }
}
