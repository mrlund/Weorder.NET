using System;
using System.Collections.Generic;
using System.Text;

namespace Weorder.NET.Entities
{
    public class Order
    {
        public string inventoryId { get; set; }
        public string orderId { get; set; }
        public Orderline[] orderLines { get; set; }
        public Customer customer { get; set; }
        public Address address { get; set; }
        public Invoice invoice { get; set; }
        public string tableSessionId { get; set; }
        public string type { get; set; }
        public int tip { get; set; }
        public int deliveryPrice { get; set; }
        public int discount { get; set; }
        public int orderTotal { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime deliveryAt { get; set; }
        public bool paid { get; set; }
        public int tableNumber { get; set; }
        public string currency { get; set; }
        public string comment { get; set; }

    }
}
