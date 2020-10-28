using System;
using System.Collections.Generic;
using System.Linq;
using Gvips.Application.Posts.Commands;
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

        public IEnumerable<Post> Handle()
        {
            return _context.Posts.ToList().OrderByDescending(b => b.BumpedAt);
        }

        public Post Handle(ListPost query)
        {
            return _context.Posts.Find(query);
        }
    }
}