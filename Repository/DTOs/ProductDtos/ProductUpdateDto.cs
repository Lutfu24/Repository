namespace Repository.DTOs.ProductDtos
{
    public record ProductUpdateDto(int Id, string Name, decimal Price, decimal DiscountPercent, string Description, bool IsInStock);
}
