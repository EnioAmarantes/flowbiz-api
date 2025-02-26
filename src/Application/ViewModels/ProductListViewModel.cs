namespace FlowBiz.Application.ViewModels;
public record ProductList(Guid Id, string Name, string ShortDescription, decimal Price) : BaseViewModel(Id);