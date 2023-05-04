using AM.ApplicationCore.Interfaces;
using System.Linq.Expressions;

namespace AM.ApplicationCore.Services;

public class Service<T> : IService<T> where T : class
{
    private readonly IGenericRepository<T> _repository;
    private readonly IUnitOfWork _unitOfWork;
    public Service(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _repository = _unitOfWork.Repository<T>();
    }

    public void Add(T entity)
    {
        _repository.Add(entity);
    }

    public void Commit()
    {
        _unitOfWork.Save();
    }

    public void Delete(T entity)
    {
        _repository.Delete(entity);
    }

    public void Delete(Expression<Func<T, bool>> where)
    {
        _repository.Delete(where);
    }

    public T Get(Expression<Func<T, bool>> where)
    {
        return _repository.Get(where);
    }

    public IEnumerable<T> GetAll()
    {
        return _repository.GetAll();
    }

    public T GetById(params object[] keyValues)
    {
        return (T)_repository.GetById(keyValues);
    }

    public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
    {
        return _repository.GetMany(where);
    }

    public void Update(T entity)
    {
        _repository.Update(entity);
    }
}
