using Application.Ports;
using Domain.Features.UserFeature;

namespace Infrastructure.Database.Repositories;

public class UserRepository : BaseRepository<User, Guid>, IUserRepository
{
    public UserRepository(SuccinctlyContext context) : base(context)
    {
    }
}