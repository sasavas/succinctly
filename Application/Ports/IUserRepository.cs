using Domain.Features.UserFeature;

namespace Application.Ports;

public interface IUserRepository : IBaseRepository<User, Guid>
{
    
}