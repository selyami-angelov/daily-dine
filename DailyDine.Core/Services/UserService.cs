using DailyDine.Core.Contracts;
using DailyDine.Infrastructure.Data.Entities;

namespace DailyDine.Core.Services
{
    public class UserService : IUserService
    {
        

        private readonly IRepository repository;

        public UserService(
            IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ApplicationUser> GetUser(string userId)
        {
            return await repository.GetByIdAsync<ApplicationUser>(userId);
        }
    }
}
