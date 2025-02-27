using FlowBiz.Application.Interfaces;
using FlowBiz.Application.Models;
using FlowBiz.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlowBiz.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var category = await _categoryService.GetByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _categoryService.GetAllAsync();
        return Ok(categories);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CategoryCreateModel category)
    {
        Category createdCategory = await _categoryService.AddAsync(category);
        return CreatedAtAction(nameof(GetById), new { id = createdCategory.Id }, category);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Category category)
    {
        if (id != category.Id)
        {
            return BadRequest();
        }

        await _categoryService.UpdateAsync(category);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _categoryService.DeleteAsync(id);
        return NoContent();
    }
}