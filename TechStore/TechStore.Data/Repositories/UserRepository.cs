using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.DbContext;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;

namespace TechStore.Data.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly TechStoreDbContext _context;
        public UserRepository(TechStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user, CancellationToken token=default)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task DeleteUser(User user, CancellationToken token=default)
        {
            _context.Users.Remove(user);
        }

        public async Task<IEnumerable<User>> GetAll(CancellationToken token=default)
        {
            return await _context.Users.ToListAsync(token);
        }

        public async Task<User?> GetById(int userId, CancellationToken token=default)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId, token);
        }

        public async Task UpdateUser(User user, CancellationToken token= default)
        {
            _context.Users.Update(user);
        }
    }
}
