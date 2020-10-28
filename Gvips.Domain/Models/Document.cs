using System;
using Gvips.Domain.Entities;
using Gvips.Domain.Enumerators;

namespace Gvips.Domain.Models
{
    public class Document : Entity
    {
        public Guid PostId { get; set; }
        public EDocumentType Type { get; set; }
        public string Origin { get; set; }
        public bool IsValid { get; set; }
        public string FileLocation { get; set; }
        public Post Post { get; set; }
    }
}