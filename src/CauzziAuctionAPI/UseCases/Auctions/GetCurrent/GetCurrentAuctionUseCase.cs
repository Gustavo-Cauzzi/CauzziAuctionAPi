using CauzziAuction.API.Contracts;
using CauzziAuction.API.Entities;
using CauzziAuction.API.Repositories;
using CauzziAuction.API.Repositories.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CauzziAuction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    private readonly IAuctionRepository _auctionRepository;

    public GetCurrentAuctionUseCase(IAuctionRepository auctionRepository)
    {
        _auctionRepository = auctionRepository;
    }

    public Auction? Execute()
    {
        return _auctionRepository.GetCurrent();
    }
}
