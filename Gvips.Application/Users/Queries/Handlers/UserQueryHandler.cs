using System;
using System.Collections.Generic;
using System.Linq;
using Gvips.Data.Context;
using Gvips.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Gvips.Application.Users.Queries.Handlers
{
    public class UserQueryHandler
    {
        private readonly DataContext _context;

        public UserQueryHandler(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<User> Handle()
        {
            return _context.Users.Include(u => u.Posts).ToList();
        }

        public User Handle(Guid id)
        {
            var user = _context.Users
                .Include(u => u.Posts)
                .FirstOrDefault(u => u.Id == id);

            return user;
        }

        public User Handle(GetUsername username)
        {
            return _context.Users.Single(u => u.UserName == username.Username);
        } 
    }
}