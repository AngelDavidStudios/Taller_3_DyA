using Microsoft.EntityFrameworkCore;
using Server.Models;
using Taller_3_DyA.Data;
using Taller_3_DyA.Repository.Interfaces;

namespace Taller_3_DyA.Repository;

public class ProductRepositoryV1: IProductRepository<ProductV1>
{
    private readonly AppDbContext _context;
    
    public ProductRepositoryV1(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<ProductV1>> GetAllAsync()
    {
        return await _context.ProductV1.ToListAsync();
    }
    
    public async Task<ProductV1> GetByIdAsync(int id)
    {
        return await _context.ProductV1.FindAsync(id);
    }
    
    public async Task<ProductV1> AddAsync(ProductV1 entity)
    {
        _context.ProductV1.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    
    public async Task<ProductV1> UpdateAsync(ProductV1 entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }
    
    public async Task<ProductV1> DeleteAsync(int id)
    {
        var entity = await _context.ProductV1.FindAsync(id);
        if (entity == null)
        {
            return null;
        }
        
        _context.ProductV1.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}