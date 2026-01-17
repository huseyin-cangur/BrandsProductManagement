

using Core.Persistence.Repositories;

namespace Core.Security.Entities
{
    public class OperationClaim : Entity<Guid>
    {
        public string Name { get; set; }
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = null!;


        public OperationClaim()
        {
            Name = string.Empty;
        }

        public OperationClaim(string name)
        {
            Name = name;
        }
        public OperationClaim(string name, Guid id) : base(id)
        {
            Name = name;
        }
    }
}