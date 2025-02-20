using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Domain.Common.Contracts;
public interface ISoftDelete
{
    string? DeletedBy { get; set; }
    DateTime? DeletedOn { get; set; }
    bool? IsDeleted { get; set; }
}

