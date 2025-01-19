using Library.Repositories;

namespace Library.Features.GetUser.V1;

public class Handler(IUserRepository userRepository)
{
    public async Task<Response?> Handle(string userId, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetUser(userId, cancellationToken);
        if (user == null) return null;
        return user.ToResponse();
    }
}