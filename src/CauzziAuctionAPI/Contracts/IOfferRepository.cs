using CauzziAuction.API.Entities;

namespace CauzziAuction.API.Contracts;

public interface IOfferRepository
{
    void Add(Offer offer);
}
