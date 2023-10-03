using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Domain.Interfaces;

    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByUserEmailAsync (string Email);
        Task<User> GetByIdAsync (int id);
     
    }
