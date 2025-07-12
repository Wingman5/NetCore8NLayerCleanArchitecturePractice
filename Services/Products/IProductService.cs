using App.Services.Models.Product;

namespace App.Services.Products
{
    public interface IProductService
    {
        Task<ServiceResult<List<ProductDto>>> GetAllAsync();
        Task<ServiceResult<List<ProductDto>>> GetPagedAllDataAsync(int pageNumber, int pageSize);
        Task<ServiceResult<List<ProductDto>>> GetTopPriceProductsAsync(int count);
        Task<ServiceResult<ProductDto?>> GetByIdAsync(int id);
        Task<ServiceResult<CreateProductResponse>> CreateAsync(CreateProductRequest productDto);
        Task<ServiceResult> UpdateAsync(int id, UpdateProductRequest productDto);
        Task<ServiceResult> UpdateStockAsync(int id, int stock);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
