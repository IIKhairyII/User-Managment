using Application.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<Domain.Entities.User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
