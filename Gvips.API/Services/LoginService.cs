using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using Gvips.API.Interfaces;
using Gvips.API.ViewModels;
using Gvips.Application.Users.Queries;
using Gvips.Application.Users.Queries.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Gvips.API.Services
{
    public class LoginService
    {
        private readonly UserQueryHandler _query;
        private readonly ITokenService _token;

        public LoginService(UserQueryHandler query, ITokenService token)
        {
            _query = query;
            _token = token;
        }

        public ActionResult<UserViewModel> login(LoginViewModel credentialsModel)
        {
            var user = _query.Handle(new GetUsername {Username = credentialsModel.Username});

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(credentialsModel.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return new UnauthorizedResult();
            }

            return new UserViewModel
            {
                Username = credentialsModel.Username,
                Token = _token.CreateToken(user)
            };
        }
    }
}