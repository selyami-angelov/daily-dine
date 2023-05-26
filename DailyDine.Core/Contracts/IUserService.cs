using DailyDine.Infrastructure.Data.Entities;

namespace DailyDine.Core.Contracts
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUser(string userId);
    }
}
