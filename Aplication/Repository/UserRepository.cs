using Domain;
using Domain.Interfaces;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Repository;
public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ApiContext _context;
    public UserRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _context.Set<User>().FindAsync(id);
    }

    public async Task<User> GetByUserEmailAsync(string email)

        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
        }

    }