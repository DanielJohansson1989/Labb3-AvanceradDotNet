namespace Labb3_AvanceradDotNet.Services
{
    public interface ILabb3<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T newEntity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
