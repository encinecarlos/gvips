using System;
using System.Collections.Generic;
using System.Linq;
using Gvips.Data.Context;
using Gvips.Domain.Models;

namespace Gvips.Application.Users.Queries.Handlers
{
    public class UserQueryHandler
    {
        private readonly DataContext _context;

        public UserQueryHandler(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<User> Handle(GetAllUsers query = null)
        {
            return _context.Users.ToList();
        }

        public User Handle(Guid id)
        {
            var user = _context.Users.Find(id);
            return user;
        }
    }
}