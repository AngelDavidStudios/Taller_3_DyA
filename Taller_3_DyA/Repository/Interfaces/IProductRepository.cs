﻿namespace Taller_3_DyA.Repository.Interfaces;

public interface IProductRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(int id);
}