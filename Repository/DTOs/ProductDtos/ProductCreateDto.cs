namespace Repository.DTOs.ProductDtos;

public record ProductCreateDto(string Name, decimal Price, decimal DiscountPercent, string Description, bool IsInStock);
