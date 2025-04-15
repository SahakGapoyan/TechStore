using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.User;
using TechStore.Data.Entity;

namespace TechStore.BLL
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAll(CancellationToken token = default);
        Task<UserDto?> GetById(int userId, CancellationToken token = default);
        Task AddUser(UserAddDto userAddDto, CancellationToken token = default);
        Task<Result> UpdateUser(int userId,UserUpdateDto userUpdateDto,CancellationToken token=default);
        Task<Result> DeleteUser(int userId, CancellationToken token=default);
    }
}
