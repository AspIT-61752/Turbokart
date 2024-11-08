namespace Turbokart.DataAccess
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void DeleteBy(T entity);
        void DeleteBy(int id);
        T GetBy(int id);
        T GetBy(T entity);
        IEnumerable<T> GetAll();
        
    }
}
