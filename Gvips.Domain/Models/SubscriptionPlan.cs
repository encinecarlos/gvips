using System.ComponentModel.DataAnnotations.Schema;
using Gvips.Domain.Entities;

namespace Gvips.Domain.Models
{
    public class SubscriptionPlan : Entity
    {
        public string Name { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        public int Recurrence { get; set; }
        public bool IsActive { get; set; }
    }
}