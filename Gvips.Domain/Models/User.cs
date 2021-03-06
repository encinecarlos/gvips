﻿using System.Collections.Generic;
using Gvips.Domain.Entities;

namespace Gvips.Domain.Models
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Avatar { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}