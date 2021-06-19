using System;
using System.Collections.Generic;
using System.Text;

namespace SwiftTraderPRoject.Models
{
    public class AdvertModel
    {
        public string Id { get; set; }
        public string SwiftTraderAdVert { get; set; }

        public static implicit operator bool(AdvertModel v)
        {
            throw new NotImplementedException();
        }
    }
}
