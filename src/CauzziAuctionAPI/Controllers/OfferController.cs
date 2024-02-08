using CauzziAuction.API.Communications.Requests;
using CauzziAuction.API.Filters;
using CauzziAuction.API.UseCases.Offers;
using Microsoft.AspNetCore.Mvc;

namespace CauzziAuction.API.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : CauzziAuctionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer(
        [FromRoute] int itemId, 
        [FromBody] RequestCreateOfferJson request,
        [FromServices] CreateOfferUseCase createOfferUseCase)
    {
        var id = createOfferUseCase.Execute(itemId, request);

        return Created(string.Empty, id);
    }
}
