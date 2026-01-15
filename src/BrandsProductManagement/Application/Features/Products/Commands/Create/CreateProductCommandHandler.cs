

using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRule _productBusinessRule;

        public CreateProductCommandHandler(IMapper mapper, ProductBusinessRule productBusinessRule, IProductRepository productRepository)
        {

            _mapper = mapper;
            _productBusinessRule = productBusinessRule;
            _productRepository = productRepository;
        }

        public async Task<CreatedProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _productBusinessRule.ProductNameCannotBeDuplicatetedWhenInserted(request.Name);

            Product product = _mapper.Map<Product>(request);
            product.Id = Guid.NewGuid();


            await _productRepository.AddAsync(product);

            CreatedProductResponse response = _mapper.Map<CreatedProductResponse>(product);

            return response;


        }
    }
}