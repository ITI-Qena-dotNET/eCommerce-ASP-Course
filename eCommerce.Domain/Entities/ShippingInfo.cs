using System.ComponentModel.DataAnnotations;

namespace eCommerce.Domain.Entities;

public sealed class ShippingInfo
{
    public int ID { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Address { get; set; }

    public string Country { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string ZipCode { get; set; }
    public int? UserID { get; set; }

    public User User { get; set; }

    public Order Order { get; set; }
}
