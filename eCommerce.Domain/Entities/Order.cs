namespace eCommerce.Domain.Entities;

public sealed class Order
{
    public int ID { get; set; }

    public DateTimeOffset PurchaseDate { get; set; }

    public IEnumerable<OrderDetail> OrderDetails { get; set; }

    public Payment Payment { get; set; }

    public User User { get; set; }

    public int ShippingInfoID { get; set; }

    public ShippingInfo ShippingInfo { get; set; }
}
