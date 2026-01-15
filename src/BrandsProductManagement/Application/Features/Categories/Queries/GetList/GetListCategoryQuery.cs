

using Core.Application.Request;
using Core.Application.Response;
using MediatR;

namespace Application.Features.Categories.Queries.GetList
{
    public class GetListCategoryQuery : IRequest<GetListResponse<GetListCategoryListItemDto>>
    {
        public PageRequest PageRequest { get; set; }

    }
}