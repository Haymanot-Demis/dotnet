using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> GetByIdAsync(int id);
        public List<T> GetAll();
        public Task<T> AddAsync(T item);
        public Task<T> UpdateAsync(T item);
        public Task DeleteAsync(T item);
    }
}
