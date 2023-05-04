
namespace AM.ApplicationCore.Interfaces;

public interface IUnitOfWork : IDisposable
{
    //public void Dispose(); hidden
    public int Save();
    public IGenericRepository<T> Repository<T>() where T: class;
}
