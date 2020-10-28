namespace Gvips.Domain.Models
{
    public class SubscriptionPlan
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Recurrence { get; set; }
        public bool IsActive { get; set; }
    }
}