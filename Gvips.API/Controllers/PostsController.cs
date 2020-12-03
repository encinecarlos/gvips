using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using AutoMapper;
using Gvips.API.ViewModels;
using Gvips.Application.Posts.Commands;
using Gvips.Application.Posts.Commands.Handlers;
using Gvips.Application.Posts.Queries;
using Gvips.Application.Posts.Queries.handlers;
using Gvips.Application.Users.Queries;
using Gvips.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gvips.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PostCommandHandler _command;
        private readonly PostQueryHandler _query;
        private readonly IMapper _mapper;

        public PostsController(PostCommandHandler command, PostQueryHandler query, IMapper mapper)
        {
            _command = command;
            _query = query;
            _mapper = mapper;
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<PostViewModel>> GetAllPosts([FromQuery] PostParameters parameters)
        {
            var postList = _query.Handle(parameters);
            var posts = _mapper.Map<IEnumerable<PostViewModel>>(postList);

            var metadata = new
            {
                postList.TotalCount,
                postList.PageSize,
                postList.CurrentPage,
                postList.TotalPages,
                postList.HasNext,
                postList.HasPrevious
            };

            //byte[] jsonstring = Encoding.UTF8.GetBytes(metadata.ToString() ?? string.Empty);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            //Response.Body.Write(jsonstring, 0, jsonstring.Length);

            return Ok(posts);
        }

        
        [HttpGet("{id:guid}")]
        public ActionResult<Post> GetById(Guid id)
        {
            return _query.Handle(new ListPost {Id = id});
        }

        
        [HttpGet("city/{city}")]
        public ActionResult<IQueryable<Post>> GetByCity(string city)
        {
            return Ok(_query.Handle(new PostByCity {City = city}));
        }

        
        [HttpGet("state/{state}")]
        public ActionResult<IQueryable<Post>> GetByState(string state)
        {
            return Ok(_query.Handle(new PostByState {State = state}));
        }

        
        [HttpGet("country/{country}")]
        public ActionResult<IQueryable<Post>> GetByCountry(string country)
        {
            return Ok(_query.Handle(new PostByCountry { Country = country}));
        }

        
        [HttpPost]
        public ActionResult<Post> CreatePost(CreatePost command)
        {
            _command.Handle(command);
            return CreatedAtAction(nameof(GetById), new {Id = command.Id}, command);
        }
    }
}