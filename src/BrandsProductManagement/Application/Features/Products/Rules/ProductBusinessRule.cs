
using Application.Features.Products.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Products.Rules
{
    public class ProductBusinessRule:BaseBusinessRules
    {
        private readonly IProductRepository _productRepository;

        public ProductBusinessRule(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task ProductNameCannotBeDuplicatetedWhenInserted(string name)
        {
            Product? product = await _productRepository.GetAsync(predicate: b => b.Name.ToLower() == name.ToLower());

            if (product != null)
            {
                throw new BusinessException(ProductMessages.ProductNameExists);
            }
        }
    }
}