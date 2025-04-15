using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.DtoModels.User;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task AddUser(UserAddDto userAddDto, CancellationToken token = default)
        {
            var user = _mapper.Map<User>(userAddDto);
            await _uow.UserRepository.AddUser(user,token);
            await _uow.SaveAsync(token);
        }

        public async Task<Result> DeleteUser(int userId, CancellationToken token = default)
        {
            var user =await _uow.UserRepository.GetById(userId, token);
            if(user==null)
            {
                return Result.Error(ErrorType.NotFound);
            }
            await _uow.UserRepository.DeleteUser(user);
            await _uow.SaveAsync(token);
            return Result.Ok("Successfully deleted");
        }

        public async Task<IEnumerable<UserDto>> GetAll(CancellationToken token = default)
        {
            var users = await _uow.UserRepository.GetAll(token);
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto?> GetById(int userId, CancellationToken token = default)
        {
            var user = await _uow.UserRepository.GetById(userId, token);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<Result> UpdateUser(int userId, UserUpdateDto userUpdateDto, CancellationToken token = default)
        {
            var user = await _uow.UserRepository.GetById(userId, token);
            if(user==null)
            {
                return Result.Error(ErrorType.NotFound);
            }
            user.FirstName = userUpdateDto.FirstName ?? user.FirstName;
            user.LastName = userUpdateDto.LastName ?? user.LastName;
            user.PhoneNumber = userUpdateDto.PhoneNumber ?? user.PhoneNumber;
            user.Address = userUpdateDto.Address ?? user.Address;
            user.Email = userUpdateDto.Email ?? user.Email;
            user.PasswordHash = userUpdateDto.PasswordHash ?? user.PasswordHash;
            await _uow.UserRepository.UpdateUser(user);
            await _uow.SaveAsync(token);
            return Result.Ok("Successfully Created");
        }
    }
}
