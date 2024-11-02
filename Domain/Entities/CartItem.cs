namespace Domain.Entities;
public class BasketItem
{
    public int Id { get; set; }
    public string BasketId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice => Price * Quantity;

    //navigational
    public virtual Basket Basket { get; set; }
    public virtual Product Product { get; set; }
}
