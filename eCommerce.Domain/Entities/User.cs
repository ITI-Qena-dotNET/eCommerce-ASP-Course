namespace eCommerce.Domain.Entities;

public sealed class User
{
    public int ID { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Address { get; set; }

    public IEnumerable<Order> Orders { get; set; }

    public IEnumerable<ShippingInfo> ShippingInfos { get; set; }
}
