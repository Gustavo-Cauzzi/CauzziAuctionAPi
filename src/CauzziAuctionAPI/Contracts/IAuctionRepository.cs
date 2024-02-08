using CauzziAuction.API.Entities;

namespace CauzziAuction.API.Contracts;

public interface IAuctionRepository
{
    Auction? GetCurrent();
}
