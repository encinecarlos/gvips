using Gvips.Domain.Entities;

namespace Gvips.Domain.Models
{
    public class Media : Entity
    {
        public string FileLocation { get; set; }
        public string Resolution { get; set; }
        public string Duration { get; set; }
        public Post Post { get; set; }
    }
}