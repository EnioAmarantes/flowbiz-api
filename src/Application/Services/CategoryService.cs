using FlowBiz.Application.Interfaces;
using FlowBiz.Application.Models;
using FlowBiz.Application.ViewModels;
using FlowBiz.Domain.Entities;
using FlowBiz.Domain.Interfaces;

namespace FlowBiz.Application.Services;

public class CategoryService : BaseService<Category, CategoryCreateModel, CategoryViewModel>, ICategoryService
{

    public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository)
    {
    }

    public override async Task<Category> AddAsync(CategoryCreateModel createModel)
    {
        Category newCategory = new Category(createModel.Name, createModel.Description);
        return await _repository.CreateAsync(newCategory);
    }

    public override async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
    {
        IEnumerable<Category> categories = await _repository.GetAsync();
        return categories.Select(c => new CategoryViewModel(c.Id, c.Name));
    }
}