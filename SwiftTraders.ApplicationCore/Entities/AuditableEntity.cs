using System;
using System.Collections.Generic;
using System.Text;

namespace SwiftTraders.ApplicationCore.Entities
{
    public class AuditableEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public bool IsDeleted { get; set; }
    }
}
