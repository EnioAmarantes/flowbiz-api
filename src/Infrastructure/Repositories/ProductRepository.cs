using FlowBiz.Domain.Entities;
using FlowBiz.Domain.Interfaces;
using FlowBiz.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FlowBiz.Infrastructure.Repositories;
public class ProductRepository: IProductRepository
{
    private readonly ApplicationContext _context;

    public ProductRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAsync()
    {
        return await _context.Products
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Product> GetByIdAsync(Guid id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<Product> CreateAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> DeleteAsync(Guid id)
    {
        var product = await _context.Products.FindAsync(id);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return _context.Products.Find(id);
    }
}