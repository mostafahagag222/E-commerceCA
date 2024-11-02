﻿namespace Domain.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int TypeId { get; set; }
        public int BrandId { get; set; }
        public int UnitsInStock { get; set; }
        public int Quantity { get; set; }
    }
}