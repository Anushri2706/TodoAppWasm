using Shared.Models;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    // ? to indicate we might return null
    Task<User?> GetByUsername(string userName);
}