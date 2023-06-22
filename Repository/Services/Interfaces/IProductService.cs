using Repository.DTOs.Common;
using Repository.DTOs.ProductDtos;

namespace Repository.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductGetResponseDto>> GetAllProductsAsync(string? search);
        Task<ProductGetResponseDto> GetProductByIdAsync(int id);
        Task<ResponseDto> CreateProductAsync(ProductCreateDto productCreateDto);
        Task<ResponseDto> UpdateProductAsync(ProductUpdateDto productUpdateDto);
        Task<ResponseDto> DeleteProductAsync(int id);
    }
}
