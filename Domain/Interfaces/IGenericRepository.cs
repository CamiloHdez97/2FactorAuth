using System.Linq.Expressions;
namespace Domain.Interfaces;
public interface IGenericRepository<T> where T : BaseEntity
{

    //Método para encontrar la primera entidad que cumple con una expresión especificada de forma asíncrona.
    Task<T> FindFirst(Expression<Func<T, bool>> expression);

    //Método para obtener de forma asíncrona todas las entidades.
    Task<IEnumerable<T>> GetAllAsync();
    //Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression);    
    //Método para buscar entidades que coincidan con una expresión especificada.
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    
    void Add (T entity);
    void AddRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    void Update(T entity);
}