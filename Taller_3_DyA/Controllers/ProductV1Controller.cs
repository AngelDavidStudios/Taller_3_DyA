using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Taller_3_DyA.Repository.Interfaces;

namespace Taller_3_DyA.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductV1Controller: ControllerBase
{
    private readonly IProductRepository<ProductV1> _productRepository;
    
    public ProductV1Controller(IProductRepository<ProductV1> productRepository)
    {
        _productRepository = productRepository;
    }
    
    [HttpGet]
    public async Task<IEnumerable<ProductV1>> GetAll()
    {
        var products = await _productRepository.GetAllAsync();
        return products;
    }
    
    [HttpGet("{id}")]
    public async Task<ProductV1> GetById(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return product;
    }
    
    [HttpPost]
    public async Task<ProductV1> Add(ProductV1 product)
    {
        var newProduct = await _productRepository.AddAsync(product);
        return newProduct;
    }
    
    [HttpPut("{id}")]
    public async Task<ProductV1> Update(int id, ProductV1 product)
    {
        product.Id = id;
        var updatedProduct = await _productRepository.UpdateAsync(product);
        return updatedProduct;
    }
    
    [HttpDelete("{id}")]
    public async Task<ProductV1> Delete(int id)
    {
        var deletedProduct = await _productRepository.DeleteAsync(id);
        return deletedProduct;
    }
}