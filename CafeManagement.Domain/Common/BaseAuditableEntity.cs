using CafeManagement.Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Domain.Common;
public abstract class BaseAuditableEntity : BaseEntity, IAuditableEntity, ISoftDelete
{
    [Column("createdon")]
    public DateTime? CreatedOn { get; set; } = DateTime.UtcNow;
    [Column("createdby")]
    public string? CreatedBy { get; set; }
    [Column("modifiedon")]
    public DateTime? ModifiedOn { get; set; } = DateTime.UtcNow;
    [Column("modifiedby")]
    public string? ModifiedBy { get; set; }
    [Column("deletedon")]
    public DateTime? DeletedOn { get; set; } = DateTime.UtcNow;
    [Column("deletedby")]
    public string? DeletedBy { get; set; }
    [Column("isdeleted")]
    public bool? IsDeleted { get; set; } = false;
}
