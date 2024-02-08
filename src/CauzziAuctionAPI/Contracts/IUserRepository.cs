using CauzziAuction.API.Entities;

namespace CauzziAuction.API.Contracts;

public interface IUserRepository
{
    bool ExistsUserWithEmail(string email);
    User GetUserByEmail(string email);
}
