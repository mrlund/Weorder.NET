namespace Weorder.NET.Entities
{
    public class Orderline
    {
        public string invenotryId { get; set; }
        public string lineId { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int discountPrice { get; set; }
        public string discountName { get; set; }
        public int vatRate { get; set; }
        public int quantity { get; set; }
        public Modifier[] modifiers { get; set; }
    }

}
