namespace Repository.DTOs.ProductDtos
{
    public record ProductGetResponseDto(string Name, decimal Price, decimal DiscountPercent, string Description, int Rating, bool IsInStock);
}
