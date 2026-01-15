

using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Product : Entity<Guid>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

 

    }
}