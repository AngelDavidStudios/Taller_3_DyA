using Microsoft.EntityFrameworkCore;
using Server.Models;
using Taller_3_DyA.Data;
using Taller_3_DyA.Repository.Interfaces;

namespace Taller_3_DyA.Repository;

public class ProductRepositoryV2: IProductRepository<ProductV2>
{
    private readonly AppDbContext _context;
    
    public ProductRepositoryV2(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<ProductV2>> GetAllAsync()
    {
        return await _context.ProductV2.ToListAsync();
    }
    
    public async Task<ProductV2> GetByIdAsync(int id)
    {
        return await _context.ProductV2.FindAsync(id);
    }
    
    public async Task<ProductV2> AddAsync(ProductV2 entity)
    {
        _context.ProductV2.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    
    public async Task<ProductV2> UpdateAsync(ProductV2 entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }
    
    public async Task<ProductV2> DeleteAsync(int id)
    {
        var entity = await _context.ProductV2.FindAsync(id);
        if (entity == null)
        {
            return null;
        }
        
        _context.ProductV2.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}