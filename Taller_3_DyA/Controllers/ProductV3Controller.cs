using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Taller_3_DyA.Repository.Interfaces;

namespace Taller_3_DyA.Controllers;

[ApiController]
[Route("api/v3/[controller]")]
public class ProductV3Controller: ControllerBase
{
    private readonly IProductRepository<ProductV3> _productRepository;
    
    public ProductV3Controller(IProductRepository<ProductV3> productRepository)
    {
        _productRepository = productRepository;
    }
    
    [HttpGet]
    public async Task<IEnumerable<ProductV3>> GetAll()
    {
        var products = await _productRepository.GetAllAsync();
        return products;
    }
    
    [HttpGet("{id}")]
    public async Task<ProductV3> GetById(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return product;
    }
    
    [HttpPost]
    public async Task<ProductV3> Add(ProductV3 product)
    {
        var newProduct = await _productRepository.AddAsync(product);
        return newProduct;
    }
    
    [HttpPut("{id}")]
    public async Task<ProductV3> Update(int id, ProductV3 product)
    {
        product.Id = id;
        var updatedProduct = await _productRepository.UpdateAsync(product);
        return updatedProduct;
    }
    
    [HttpDelete("{id}")]
    public async Task<ProductV3> Delete(int id)
    {
        var deletedProduct = await _productRepository.DeleteAsync(id);
        return deletedProduct;
    }
}