using FlowBiz.Application.Interfaces;
using FlowBiz.Domain.Interfaces;

namespace FlowBiz.Application.Services;

public abstract class BaseService<Base, BaseCreateModel, BaseViewModel> : ICRUDService<Base, BaseCreateModel, BaseViewModel>
{
    protected readonly IBaseRepository<Base> _repository;

    public BaseService(IBaseRepository<Base> repository)
        => _repository = repository;

    public abstract Task<Base> AddAsync(BaseCreateModel createModel);

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public abstract Task<IEnumerable<BaseViewModel>> GetAllAsync();

    public async Task<Base> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Base> UpdateAsync(Base model)
    {
        return await _repository.UpdateAsync(model);
    }
}