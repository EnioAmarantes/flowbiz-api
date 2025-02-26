namespace FlowBiz.Domain.Entities;

public class Product : Base 
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public decimal Price { get; set; }

    public Product(string code, string name, string description, Guid categoryId, decimal price)
        : base()
    {
        Code = code;
        Name = name;
        Description = description;
        CategoryId = categoryId;
        Price = price;
    }
}