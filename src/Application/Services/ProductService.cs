using FlowBiz.Application.Interfaces;
using FlowBiz.Application.Models;
using FlowBiz.Application.ViewModels;
using FlowBiz.Domain.Entities;
using FlowBiz.Domain.Interfaces;

namespace FlowBiz.Application.Services;

public class ProductService : BaseService<Product, ProductCreateModel, ProductList>, IProductService
{

    public ProductService(IProductRepository productRepository) : base(productRepository)
    {
    }

    public override async Task<Product> AddAsync(ProductCreateModel createModel)
    {
        Product newProduct = new Product(
            code: createModel.Code,
            name: createModel.Name,
            description: createModel.Description,
            categoryId: createModel.CategoryId,
            price: createModel.Price
        );
        return await _repository.CreateAsync(newProduct);
    }

    public override async Task<IEnumerable<ProductList>> GetAllAsync(){
        IEnumerable<Product> products = await _repository.GetAsync();
        return products.Select(p => new ProductList(p.Id, p.Name, p.Description, p.Price));
    }
}