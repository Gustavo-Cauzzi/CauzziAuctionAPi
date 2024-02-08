using CauzziAuction.API.Contracts;
using CauzziAuction.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CauzziAuction.API.Repositories.DataAccess;

public class AuctionRepository : IAuctionRepository
{
    private readonly CauzziAuctionDbContext _dbContext;
    public AuctionRepository(CauzziAuctionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Auction? GetCurrent()
    {
        var today = DateTime.Now;

        return _dbContext
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
    }
}
