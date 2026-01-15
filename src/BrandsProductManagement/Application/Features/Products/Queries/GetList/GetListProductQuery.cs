
using Core.Application.Request;
using Core.Application.Response;
using MediatR;

namespace Application.Features.Products.Queries.GetList
{
    public class GetListProductQuery : IRequest<GetListResponse<GetListProductListItemDto>>
    {
        public PageRequest PageRequest { get; set; }

    }
}