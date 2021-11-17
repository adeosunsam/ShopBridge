namespace ShopBridge_model
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double ProductPrice { get; set; }
        public string ThumbNail { get; set; }
    }
}
