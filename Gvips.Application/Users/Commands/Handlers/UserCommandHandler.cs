using System;
using Gvips.Data.Context;
using Gvips.Domain.Models;

namespace Gvips.Application.Users.Commands.Handlers
{
    public class UserCommandHandler
    {
        private readonly DataContext _context;

        public UserCommandHandler(DataContext context)
        {
            _context = context;
        }

        public void Handle(CreateUser command)
        {
            var user = new User
            {
                UserName = command.UserName,
                Email = command.Email,
                Password = command.Password
            };
            
            command.Id = user.Id;

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Handle(EditUser command)
        {
            var user = _context.Users.Find(command.Id);

            user.UserName = command.UserName ?? user.UserName;
            user.Email = command.Email ?? user.Email;
            user.Password = command.Password ?? user.Password;
            user.Avatar = command.Avatar ?? user.Avatar;

            _context.SaveChanges();
        }

        public void Handle(Guid id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}