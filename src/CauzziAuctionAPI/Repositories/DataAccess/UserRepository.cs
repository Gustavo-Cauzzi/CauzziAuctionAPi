using CauzziAuction.API.Contracts;
using CauzziAuction.API.Entities;

namespace CauzziAuction.API.Repositories.DataAccess;

public class UserRepository : IUserRepository
{
    private readonly CauzziAuctionDbContext _dbContext;
    public UserRepository(CauzziAuctionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool ExistsUserWithEmail (string email)
    {
        return _dbContext.Users.Any(user => user.Email.Equals(email));
    }
    
    public User GetUserByEmail(string email)
    {
        return _dbContext.Users.First(user => user.Email.Equals(email));
    }
}
