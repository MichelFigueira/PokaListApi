using System;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PokaList.Application.Contracts;
using PokaList.Application.Dtos;
using PokaList.Domain.Identity;
using PokaList.Persistence.Contracts;

namespace PokaList.Application
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUserPersist _userPersist;
        private readonly IPokaPersist _pokaPersist;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IUserPersist userPersist, IPokaPersist pokaPersist)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userPersist = userPersist;
            _pokaPersist = pokaPersist;
        }

        public async Task<SignInResult> CheckUserPasswordAsync(UserUpdateDto userUpdateDto, string password)
        {
            try
            {
                var user = await _userManager.Users
                                             .SingleOrDefaultAsync(u => u.UserName == userUpdateDto.UserName.ToLower());

                return await _signInManager.CheckPasswordSignInAsync(user, password, false);

            }
            catch (Exception ex)
            {
                throw new Exception($"Error: { ex.Message }");
            }
            
        }

        public async Task<UserUpdateDto> CreateAccountAsync(UserDto userDto)
        {
            try
            {

                var user = _mapper.Map<User>(userDto);
                var result = await _userManager.CreateAsync(user, userDto.Password);

                if (result.Succeeded)
                {
                    var userToReturn = _mapper.Map<UserUpdateDto>(user);

                    if (userDto.DefaultData == "true")
                    _pokaPersist.CreateDefaultPokas(user.Id, 2);

                    return userToReturn;
                }

                return null;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error: { ex.Message }");
            }
        }

        public async Task<UserUpdateDto> GetUserByUserNameAsync(string userName)
        {
            try
            {
                var user = await _userPersist.GetUserByUserNameAsync(userName);
                if (user == null) return null;

                var userUpdateDto = _mapper.Map<UserUpdateDto>(user);
                return userUpdateDto;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error: { ex.Message }");
            }
        }

        public async Task<UserUpdateDto> UpdateAccount(UserUpdateDto userUpdateDto)
        {
            try
            {
                var user = await _userPersist.GetUserByUserNameAsync(userUpdateDto.UserName);
                if (user == null) return null;

                userUpdateDto.Id = user.Id;

                _mapper.Map(userUpdateDto, user);

                if(userUpdateDto.Password != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    await _userManager.ResetPasswordAsync(user, token, userUpdateDto.Password);
                }

                _userPersist.Update<User>(user);

                if (await _userPersist.SaveChangesAsync())
                {
                    var userReturn = await _userPersist.GetUserByUserNameAsync(user.UserName);

                    return _mapper.Map<UserUpdateDto>(userReturn);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: { ex.Message }");
            }
        }

        public async Task<bool> UserExists(string userName)
        {
            try
            {
                return await _userManager.Users.AnyAsync(u => u.UserName == userName.ToLower());

            }
            catch (Exception ex)
            {
                throw new Exception($"Error: { ex.Message }");
            }
        }

    }
}
