using System;
using Gvips.Domain.Entities;

namespace Gvips.Domain.Models
{
    public class Subscription : Entity
    {
        public string TransactionCode { get; set; }
        public bool IsActive { get; set; }
        public SubscriptionPlan Plan { get; set; }
        public Guid PlanId { get; set; }
        public Post Post { get; set; }
        public Guid PostId { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}