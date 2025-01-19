using Library.Entities;

namespace Library.Repositories;

public interface IUserRepository
{
    public Task<User?> GetUser(string id, CancellationToken cancellationToken);
}