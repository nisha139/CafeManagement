using CafeManagement.Domain.Common;

namespace CafeManagement.Domain.Entities;
public class Order : BaseAuditableEntity
{
    public int Id { get; set; }
    public List<int> MenuItemIds { get; set; } = new();
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
}
