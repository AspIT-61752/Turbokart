using Turbokart.Entities;

namespace Turbokart.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void DeleteBy(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void DeleteBy(int id)
        {
            T entity = GetBy(id);
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T GetBy(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T GetBy(T entity)
        {
            return _context.Set<T>().Find(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
