using System;
using System.Collections.Generic;
using Gvips.Application.Users.Commands;
using Gvips.Application.Users.Commands.Handlers;
using Gvips.Application.Users.Queries.Handlers;
using Gvips.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gvips.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserQueryHandler _query;
        private readonly UserCommandHandler _command;

        public UsersController(UserQueryHandler query, UserCommandHandler command)
        {
            _query = query;
            _command = command;
        }

        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _query.Handle();
        }

        [HttpPost]
        public ActionResult<CreateUser> CreateUser(CreateUser command)
        {
            _command.Handle(command);
            return CreatedAtAction(nameof(ShowUser), new {Id = command.Id}, command);
        }

        [HttpGet("{id:guid}")]
        public ActionResult<User> ShowUser(Guid id)
        {
            return _query.Handle(id);
        }

        [HttpPut("{id:guid}")]
        public ActionResult<EditUser> UpdateUser(Guid id, EditUser command)
        {
            command.Id = id;
            _command.Handle(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DestroyUser(Guid id)
        {
            _command.Handle(id);
            return Ok();
        }
    }
}