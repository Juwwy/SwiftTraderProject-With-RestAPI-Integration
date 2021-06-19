using System;
using System.Collections.Generic;
using System.Text;

namespace SwiftTraders.ApplicationCore.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public decimal WalletBalance { get; set; }
        public string Telephone { get; set; }
        public string UserRole { get; set; }
    }
}
