using Persistence;
using Aplication.Repository;
using Domain.Interfaces;

namespace Aplication.UnitOfWork;

    public class UnitOfWork : IUnitOfWork, IDisposable{
    private readonly ApiContext _context;

    private UserRepository _User;

    public UnitOfWork(ApiContext context)
    {
        _context = context;
    }
        
        public IUserRepository Users
        {
            get
            {
                if (_User is not null)
                {
                    return _User;
                }
                return _User = new UserRepository(_context);
            }
        }
   
        public void Dispose(){
            _context.Dispose();
        }

        public async Task<int> SaveAsync(){
            return await _context.SaveChangesAsync();
        }
 } 


















