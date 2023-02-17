namespace HrLeaveManagement.Application.Contracts.Presistence.Repositories;

public interface IGenericRepository<T> where T:class
{
    Task<T> Get(int id);
    Task<IReadOnlyList<T>> GetAll();
    Task<bool> IsExistById(int id);
    Task<T> Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}