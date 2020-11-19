using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Gvips.Data.Context;
using Gvips.Domain.Models;
using Microsoft.EntityFrameworkCore.Internal;

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
            using var hmac = new HMACSHA512();

            var user = new User
            {
                UserName = command.UserName,
                Email = command.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(command.Password)),
                PasswordSalt = hmac.Key
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
            //user.Password = command.Password ?? user.Password;
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