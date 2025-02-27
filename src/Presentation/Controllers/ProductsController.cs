using FlowBiz.Application.Interfaces;
using FlowBiz.Application.Models;
using FlowBiz.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlowBiz.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProductCreateModel product)
    {
        Product createdProduct = await _productService.AddAsync(product);
        return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        Product updatedProduct = await _productService.UpdateAsync(product);
        return CreatedAtAction(nameof(GetById), new { id = updatedProduct}, updatedProduct);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _productService.DeleteAsync(id);
        return NoContent();
    }
}