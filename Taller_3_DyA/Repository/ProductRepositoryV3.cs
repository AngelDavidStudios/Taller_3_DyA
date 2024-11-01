using Microsoft.EntityFrameworkCore;
using Server.Models;
using Taller_3_DyA.Data;
using Taller_3_DyA.Repository.Interfaces;

namespace Taller_3_DyA.Repository;

public class ProductRepositoryV3: IProductRepository<ProductV3>
{
    private readonly AppDbContext _context;
    
    public ProductRepositoryV3(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<ProductV3>> GetAllAsync()
    {
        return await _context.ProductV3.ToListAsync();
    }
    
    public async Task<ProductV3> GetByIdAsync(int id)
    {
        return await _context.ProductV3.FindAsync(id);
    }
    
    public async Task<ProductV3> AddAsync(ProductV3 entity)
    {
        _context.ProductV3.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    
    public async Task<ProductV3> UpdateAsync(ProductV3 entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }
    
    public async Task<ProductV3> DeleteAsync(int id)
    {
        var entity = await _context.ProductV3.FindAsync(id);
        if (entity == null)
        {
            return null;
        }
        
        _context.ProductV3.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}