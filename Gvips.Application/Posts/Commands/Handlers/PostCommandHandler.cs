using System;
using Gvips.Data.Context;
using Gvips.Domain.Models;

namespace Gvips.Application.Posts.Commands.Handlers
{
    public class PostCommandHandler
    {
        private readonly DataContext _context;

        public PostCommandHandler(DataContext context)
        {
            _context = context;
        }

        public void Handle(CreatePost command)
        {
            var post = new Post
            {
                Name = command.Name,
                Age = command.Age,
                PostEmail = command.PostEmail,
                Phone = command.Phone,
                Country = command.Country,
                City = command.City,
                State = command.State,
                Bust = command.Bust,
                Cup = command.Cup,
                Description = command.Description,
                Ethnicity = command.Ethnicity,
                HairColor = command.HairColor,
                ShortDescription = command.ShortDescription,
                Gender = command.Gender,
                Eyes = command.Eyes,
                Height = command.Height,
                Weight = command.Weight,
                Hips = command.Hips,
                Incall = command.Incall,
                Outcall = command.Outcall,
                Waist = command.Waist,
                AvailableTo = command.AvailableTo,
                OnlineStatus = command.OnlineStatus,
                SocialNetworks = command.SocialNetworks,
                Affiliation = command.Affiliation,
                BumpedAt = DateTime.Now,
                UserId = command.UserId
            };

            command.Id = post.Id;

            _context.Posts.Add(post);
            _context.SaveChanges();
        }
    }
}