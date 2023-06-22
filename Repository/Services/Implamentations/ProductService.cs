using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repository.DTOs.Common;
using Repository.DTOs.ProductDtos;
using Repository.Exceptions.ProductExceptions;
using Repository.Models;
using Repository.Repositories.Interfaces;
using Repository.Services.Interfaces;
using System.Net;

namespace Repository.Services.Implamentations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ResponseDto> CreateProductAsync(ProductCreateDto productCreateDto)
    {
        bool isExist = await _productRepository.IsExistAsync(p => p.Name == productCreateDto.Name);
        if (isExist)
            throw new ProductAlreadyExistException($"Product already exist with name: {productCreateDto.Name}");

        Product product = _mapper.Map<Product>(productCreateDto);

        await _productRepository.CreateAsync(product);
        await _productRepository.SaveAsync();

        return new(HttpStatusCode.Created, "Product successfully created");
    }

    public async Task<ResponseDto> DeleteProductAsync(int id)
    {
        var product = await _productRepository.GetSingleAsync(p => p.Id == id);
        if (product is null)
            throw new ProductNotFoundException($"Product not found by id: {id}");

        _productRepository.SoftDelete(product);
        await _productRepository.SaveAsync();

        return new(HttpStatusCode.OK, "Product successfully deleted");
    }

    public async Task<List<ProductGetResponseDto>> GetAllProductsAsync(string? search)
    {
        List<Product> products = await _productRepository
            .GetFiltered(p => search != null ? p.Name.ToLower().Trim().Contains(search.Trim().ToLower()) : true).ToListAsync();

        var productDtos = _mapper.Map<List<ProductGetResponseDto>>(products);

        return productDtos;
    }

    public async Task<ProductGetResponseDto> GetProductByIdAsync(int id)
    {
        Product product = await _productRepository.GetByIdAsync(id);
        if (product is null)
            throw new ProductNotFoundException($"Product not found by id: {id}");

        var productDto = _mapper.Map<ProductGetResponseDto>(product);

        return productDto;
    }

    public async Task<ResponseDto> UpdateProductAsync(ProductUpdateDto productUpdateDto)
    {
        bool isExist = await _productRepository.IsExistAsync(p => p.Name == productUpdateDto.Name && p.Id != productUpdateDto.Id);
        if (isExist)
            throw new ProductAlreadyExistException($"Product already exist with name: {productUpdateDto.Name}");

        Product product = await _productRepository.GetByIdAsync(productUpdateDto.Id);
        if (product is null)
            throw new ProductNotFoundException($"Product not found by id: {productUpdateDto.Id}");

        var updatedProduct = _mapper.Map(productUpdateDto, product);

        _productRepository.Update(updatedProduct);
        await _productRepository.SaveAsync();

        return new(HttpStatusCode.OK, "Product successfully updated");
    }
}
