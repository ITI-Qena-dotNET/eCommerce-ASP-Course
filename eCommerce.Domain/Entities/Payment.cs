using eCommerce.Domain.Enums;

namespace eCommerce.Domain.Entities;

public sealed class Payment
{
    public int ID { get; set; }

    public decimal Amount { get; set; }

    public DateTimeOffset PaymentDate { get; set; }

    public PaymentMethod PaymentMethod { get; set; }

    public int OrderID { get; set; }

    public Order Order { get; set; }
}
