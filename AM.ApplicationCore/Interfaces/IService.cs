
using System.Linq.Expressions;
using System.Transactions;

namespace AM.ApplicationCore.Interfaces;

public interface IService<T> where T : class
{
    public void Add(T entity);
    public void Update(T entity);
    public void Delete(T entity);
    public void Delete(Expression<Func<T, bool>> where); 
    public T Get(Expression<Func<T, bool>> where);
    public T GetById(params object[] keyValues);
    public IEnumerable<T> GetAll();
    public IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    public void Commit();
}
