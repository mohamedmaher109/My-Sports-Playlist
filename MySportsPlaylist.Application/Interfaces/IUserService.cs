using MySportsPlaylist.Application.DTOs.Auth;

namespace MySportsPlaylist.Application.Interfaces;

public interface IUserService
{
    Task<(bool IsSuccessful, IEnumerable<string> Errors)> RegisterAsync(RegisterDto model);
    Task<(bool IsSuccessful, string Token, string ErrorMessage)> LoginAsync(LoginDto model);
}