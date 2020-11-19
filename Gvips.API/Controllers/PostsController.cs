using System;
using System.Collections.Generic;
using System.Linq;
using Gvips.Application.Posts.Commands;
using Gvips.Application.Posts.Commands.Handlers;
using Gvips.Application.Posts.Queries;
using Gvips.Application.Posts.Queries.handlers;
using Gvips.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gvips.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PostCommandHandler _command;
        private readonly PostQueryHandler _query;

        public PostsController(PostCommandHandler command, PostQueryHandler query)
        {
            _command = command;
            _query = query;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetAllPosts()
        {
            var posts = _query.Handle();
            return Ok(posts);
        }

        [Authorize]
        [HttpGet("{id:guid}")]
        public ActionResult<Post> GetById(Guid id)
        {
            return _query.Handle(new ListPost {Id = id});
        }

        [Authorize]
        [HttpGet("city/{city}")]
        public ActionResult<IQueryable<Post>> GetByCity(string city)
        {
            return Ok(_query.Handle(new PostByCity {City = city}));
        }

        [Authorize]
        [HttpGet("state/{state}")]
        public ActionResult<IQueryable<Post>> GetByState(string state)
        {
            return Ok(_query.Handle(new PostByState {State = state}));
        }

        [Authorize]
        [HttpGet("country/{country}")]
        public ActionResult<IQueryable<Post>> GetByCountry(string country)
        {
            return Ok(_query.Handle(new PostByCountry { Country = country}));
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Post> CreatePost(CreatePost command)
        {
            _command.Handle(command);
            return CreatedAtAction(nameof(GetById), new {Id = command.Id}, command);
        }
    }
}