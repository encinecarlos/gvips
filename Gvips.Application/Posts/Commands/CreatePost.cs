using System;
using Gvips.Domain.Enumerators;

namespace Gvips.Application.Posts.Commands
{
    public class CreatePost
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string PostEmail { get; set; }
        public EEthnicity Ethnicity { get; set; }
        public string Eyes { get; set; }
        public string SocialNetworks { get; set; }
        public EGender Gender { get; set; }
        public string Height { get; set; }
        public string Hips { get; set; }
        public EHairColor HairColor { get; set; }
        public int Incall { get; set; }
        public int Outcall { get; set; }
        public EAffiliation Affiliation { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public EOnlineStatus OnlineStatus { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Waist { get; set; }
        public string Weight { get; set; }
        public string Bust { get; set; }
        public ECup Cup { get; set; }
        public string AvailableTo { get; set; }
        public DateTime BumpedAt { get; set; }
    }
}