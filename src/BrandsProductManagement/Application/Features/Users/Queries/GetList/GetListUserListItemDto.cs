

namespace Application.Features.Users.Queries.GetList
{
    public class GetListUserListItemDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Guid> OperationClaimIds { get; set; }
        public bool Status { get; set; }
    }
}