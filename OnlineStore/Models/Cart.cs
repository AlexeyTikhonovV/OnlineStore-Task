namespace OnlineStore.Models
{
    public class Cart
    {
        public int CartId { get; set; }  
        public int CommodityNamber { get; set; }

        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
