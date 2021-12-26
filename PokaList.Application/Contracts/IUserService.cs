using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PokaList.Application.Dtos;


namespace PokaList.Application.Contracts
{
    public interface IUserService
    {
        Task<bool> UserExists(string userName);
        Task<UserUpdateDto> GetUserByUserNameAsync(string userName);
        Task<SignInResult> CheckUserPasswordAsync(UserUpdateDto userUpdateDto, string password);
        Task<UserUpdateDto> CreateAccountAsync(UserDto userDto);
        Task<UserUpdateDto> UpdateAccount(UserUpdateDto userUpdateDto);

    }
}
