using CauzziAuction.API.Contracts;
using CauzziAuction.API.Entities;

namespace CauzziAuction.API.Repositories.DataAccess;

public class OfferRepository : IOfferRepository
{
    private readonly CauzziAuctionDbContext _dbContext;
    public OfferRepository(CauzziAuctionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Offer offer)
    {
        _dbContext.Offers.Add(offer);
        _dbContext.SaveChanges();
    }
}


