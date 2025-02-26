namespace FlowBiz.Application.Interfaces;

public interface ICRUDService<T, Y, Z> {
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<Z>> GetAllAsync();
    Task<T> AddAsync(Y createModel);
    Task<T> UpdateAsync(T model);
    Task DeleteAsync(Guid id);
}