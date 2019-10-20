namespace Weorder.NET.Entities
{
    public class Modifier
    {
        public string id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int discountPrice { get; set; }
        public string discountName { get; set; }
        public int vatRate { get; set; }
        public int quantity { get; set; }
    }

}
