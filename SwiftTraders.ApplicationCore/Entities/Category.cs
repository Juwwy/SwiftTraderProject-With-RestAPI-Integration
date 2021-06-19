using System;
using System.Collections.Generic;
using System.Text;

namespace SwiftTraders.ApplicationCore.Entities
{
    public class Category : AuditableEntity
    {
        public string CategoryName { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
    }
}
