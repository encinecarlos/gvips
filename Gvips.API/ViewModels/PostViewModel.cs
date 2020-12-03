using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Gvips.Domain.Enumerators;
using Gvips.Domain.Models;

namespace Gvips.API.ViewModels
{
    public class PostViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public EGender Gender { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public List<Media> Photos { get; set; }
        public Subscription Subscription { get; set; }
    }
}