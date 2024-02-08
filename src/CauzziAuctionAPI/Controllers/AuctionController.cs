using CauzziAuction.API.Entities;
using CauzziAuction.API.UseCases.Auctions.GetCurrent;
using Microsoft.AspNetCore.Mvc;

namespace CauzziAuction.API.Controllers;

public class AuctionController : CauzziAuctionBaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuction([FromServices] GetCurrentAuctionUseCase useCase)
    {
        var currentAuction = useCase.Execute();

        if (currentAuction is null) return NoContent();

        return Ok(currentAuction);
    }
}
