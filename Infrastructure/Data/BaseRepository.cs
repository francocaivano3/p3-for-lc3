using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public abstract class BaseRepository<T> where T : class
    {
        protected readonly ApplicationContext _context;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<T> Get() 
        {
            return _context.Set<T>().ToList();
        }

        public T Create(T entity) 
        {
           _context.Set<T>().Add(entity);
           _context.SaveChanges();
            return entity; 
        }
    }
}
