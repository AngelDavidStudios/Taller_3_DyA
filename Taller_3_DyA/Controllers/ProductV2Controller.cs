using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Taller_3_DyA.Repository.Interfaces;

namespace Taller_3_DyA.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
public class ProductV2Controller: ControllerBase
{
    private readonly IProductRepository<ProductV2> _productRepository;
    
    public ProductV2Controller(IProductRepository<ProductV2> productRepository)
    {
        _productRepository = productRepository;
    }
    
    [HttpGet]
    public async Task<IEnumerable<ProductV2>> GetAll()
    {
        var products = await _productRepository.GetAllAsync();
        return products;
    }
    
    [HttpGet("{id}")]
    public async Task<ProductV2> GetById(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return product;
    }
    
    [HttpPost]
    public async Task<ProductV2> Add(ProductV2 product)
    {
        var newProduct = await _productRepository.AddAsync(product);
        return newProduct;
    }
    
    [HttpPut("{id}")]
    public async Task<ProductV2> Update(int id, ProductV2 product)
    {
        product.Id = id;
        var updatedProduct = await _productRepository.UpdateAsync(product);
        return updatedProduct;
    }
    
    [HttpDelete("{id}")]
    public async Task<ProductV2> Delete(int id)
    {
        var deletedProduct = await _productRepository.DeleteAsync(id);
        return deletedProduct;
    }
}