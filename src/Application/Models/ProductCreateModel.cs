namespace FlowBiz.Application.Models;
public record ProductCreateModel(
    string Code,
    string Name, 
    string Description,
    Guid CategoryId,
    decimal Price) 
    : BaseCreateModel(Name);