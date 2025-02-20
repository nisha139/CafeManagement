using CafeManagement.Domain.Common;

namespace CafeManagement.Domain.Entities;
    public class CafeMenu : BaseAuditableEntity
{
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
    }


