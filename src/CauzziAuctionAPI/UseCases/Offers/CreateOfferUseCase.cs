using CauzziAuction.API.Communications.Requests;
using CauzziAuction.API.Contracts;
using CauzziAuction.API.Entities;
using CauzziAuction.API.Services;

namespace CauzziAuction.API.UseCases.Offers;

public class CreateOfferUseCase
{
    private readonly ILoggedUser _loggedUser;
    public readonly IOfferRepository _repository;

    public CreateOfferUseCase(ILoggedUser loggedUser, IOfferRepository repository) {
        _loggedUser = loggedUser;
        _repository = repository;
     }

    public int Execute(int itemId, RequestCreateOfferJson request)
    {
        var user = _loggedUser.User();

        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id,
        };

        _repository.Add(offer);

        return offer.Id;
    }
}
