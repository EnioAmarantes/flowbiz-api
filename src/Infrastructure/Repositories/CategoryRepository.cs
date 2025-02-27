using FlowBiz.Domain.Entities;
using FlowBiz.Domain.Interfaces;
using FlowBiz.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FlowBiz.Infrastructure.Repositories;

public class CategoryRepository: ICategoryRepository
{
    private readonly ApplicationContext _context;

    public CategoryRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAsync()
    {
        return await _context.Categories
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Category> GetByIdAsync(Guid id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task<Category> CreateAsync(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> DeleteAsync(Guid id)
    {
        var category = await _context.Categories.FindAsync(id);
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return _context.Categories.Find(id);
    }
}