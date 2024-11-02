namespace Domain.Entities;

public class Basket
{
    public string Id { get; set; }
    public int TotalQuantity { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int? UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public string ShippingMethodId { get; set; }
    public string Guid { get; set; }
    public decimal SubTotal { get; set; }

    //navigational
    public virtual User User { get; set; }
    public virtual ShippingMethod ShippingMethod { get; set; }
    public virtual List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    public virtual List<Payment> Payments { get; set; } = new List<Payment>();
    public virtual Order Order { get; set; }

}
