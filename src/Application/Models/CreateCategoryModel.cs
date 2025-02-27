namespace FlowBiz.Application.Models;
public record CategoryCreateModel(string Name, string Description) 
    : BaseCreateModel(Name);