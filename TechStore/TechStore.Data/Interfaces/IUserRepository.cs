using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.Entity;

namespace TechStore.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll(CancellationToken token=default);
        Task<User?> GetById(int userId, CancellationToken token= default);
        Task AddUser(User user, CancellationToken token = default);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
    }
}
