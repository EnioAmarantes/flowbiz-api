namespace FlowBiz.Domain.Entities;

public class Category : Base
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Product> Products {get; set; }
    public Category(string Name, string Description = ""): base()
    {
        this.Name = Name;
        this.Description = Description;
    }
}