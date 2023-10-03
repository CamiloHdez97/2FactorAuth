namespace Domain.Interfaces;

public interface IUnitOfWork{
    
    IUserRepository Users {get;}

    //Es el nombre del método que guarda los cambios en el contexto de la base de datos.
    Task<int> SaveAsync();

}