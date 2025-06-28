using System.Net;
using App.Repositories;
using App.Repositories.Products;
using App.Services.Models;

namespace App.Services.Products
{
    public class ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork) : IProductService
    {
        public async Task<ServiceResult<List<ProductDto>>> GetTopPriceProductsAsync(int count)
        {
            var products = await productRepository.GetTopPriceProductsAsync(count);

            var productsAsDto = products.Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock)).ToList();

            return ServiceResult<List<ProductDto>>.Success(productsAsDto);
        }

        public async Task<ServiceResult<ProductDto>> GetProductByIdAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);

            if (product is null)
            {
                return ServiceResult<ProductDto>.NotFound();
            }

            var productDto = new ProductDto(product.Id, product.Name, product.Price, product.Stock);

            return ServiceResult<ProductDto>.Success(productDto);
        }

        public async Task<ServiceResult<CreateProductResponse>> CreateProductAsync(CreateProductRequest productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Stock = productDto.Stock
            };
            await productRepository.AddAsync(product);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult<CreateProductResponse>.Success(new CreateProductResponse(product.Id), HttpStatusCode.Created);
        }
    }
}
