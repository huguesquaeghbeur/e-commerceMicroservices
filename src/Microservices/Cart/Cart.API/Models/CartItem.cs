﻿namespace Cart.API.Models
{
    public class CartItem
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string ProductId { get; set; }
        public string Productname { get; set; }
    }
}
