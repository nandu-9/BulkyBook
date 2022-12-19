using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    // Note: Here we are implimenting the generics.
    public interface IRepository<T> where T : class
    {
        // This method takes a link expression with a function with T parameter and bool return type
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        
        // Method to manage DB
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);


    }
}
