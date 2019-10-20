namespace Weorder.NET.Entities
{
    public class Article
    {
        public string id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int vatRate { get; set; }
        public string currency { get; set; }
        public string[] modifierGroups { get; set; }
    }


}
