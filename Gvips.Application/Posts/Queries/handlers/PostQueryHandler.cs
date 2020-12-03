using System;
using System.Collections.Generic;
using System.Linq;
using Gvips.Application.Posts.Commands;
using Gvips.Application.Services;
using Gvips.Application.Users.Queries;
using Gvips.Data.Context;
using Gvips.Domain.Models;

namespace Gvips.Application.Posts.Queries.handlers
{
    public class PostQueryHandler
    {
        private readonly DataContext _context;

        public PostQueryHandler(DataContext context)
        {
            _context = context;
        }

        //public IEnumerable<Post> Handle(PostParameters parameters)
        //{
        //    return _context.Posts
        //        .OrderBy(b => b.BumpedAt)
        //        .Skip((parameters.PageNumber - 1) * parameters.PageSize)
        //        .Take(parameters.PageSize)
        //        .ToList();
        //}

        public PagedList<Post> Handle(PostParameters parameters)
        {
            return PagedList<Post>.ToPagedList(_context.Posts.OrderBy(p => p.BumpedAt), 
                parameters.PageNumber, 
                parameters.PageSize);
        }

        public Post Handle(ListPost query)
        {
            return _context.Posts.Find(query.Id);
        }

        public IQueryable<Post> Handle(PostByCity location)
        {
            return _context.Posts.Where(p => p.City == location.City);
        }

        public IQueryable<Post> Handle(PostByState location)
        {
            return _context.Posts.Where(p => p.State == location.State);
        }

        public IQueryable<Post> Handle(PostByCountry location)
        {
            return _context.Posts.Where(p => p.Country == location.Country);
        }
    }
}