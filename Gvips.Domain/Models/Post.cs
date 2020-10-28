using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Gvips.Domain.Entities;
using Gvips.Domain.Enumerators;

namespace Gvips.Domain.Models
{
    public class Post : Entity
    {
        public Post()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Code = Guid.NewGuid()
                .ToString()
                .Replace("-", "")
                .Substring(0, 6)
                .Insert(0, "POST_").ToUpper();
        }
        public Guid UserId { get; set; }
        public string Code { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(3)]
        public int Age { get; set; }
        [MaxLength(255)]
        public string PostEmail { get; set; }
        public EEthnicity Ethnicity { get; set; }
        [MaxLength(10)]
        public string Eyes { get; set; }
        public string SocialNetworks { get; set; }
        public EGender Gender { get; set; }
        [MaxLength(5)]
        public string Height { get; set; }
        [MaxLength(5)]
        public string Hips { get; set; }
        public EHairColor HairColor { get; set; }
        public int Incall { get; set; }
        public int Outcall { get; set; }
        public EAffiliation Affiliation { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }
        [MaxLength(30)]
        public string Country { get; set; }
        [MaxLength(30)]
        public string State { get; set; }
        [MaxLength(30)]
        public string City { get; set; }
        public EOnlineStatus OnlineStatus { get; set; }
        [MaxLength(140)]
        public string ShortDescription { get; set; }
        [MaxLength(5000)]
        public string Description { get; set; }
        [MaxLength(5)]
        public string Waist { get; set; }
        [MaxLength(5)]
        public string Weight { get; set; }
        [MaxLength(5)]
        public string Bust { get; set; }
        public ECup Cup { get; set; }
        public string AvailableTo { get; set; }
        public List<Media> Photos { get; set; }
        public Document Document { get; set; }
        public DateTime BumpedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}