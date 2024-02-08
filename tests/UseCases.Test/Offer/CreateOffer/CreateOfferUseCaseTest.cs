
using Bogus;
using CauzziAuction.API.Communications.Requests;
using CauzziAuction.API.Contracts;
using CauzziAuction.API.Entities;
using CauzziAuction.API.Enums;
using CauzziAuction.API.Services;
using CauzziAuction.API.UseCases.Auctions.GetCurrent;
using CauzziAuction.API.UseCases.Offers;
using FluentAssertions;
using Moq;
using Xunit;

namespace UseCases.Test.Auction.GetCurrent;
public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId)
    {
        // AAA = Arrenge, Act, Assert
        // Arrenge
        var request = new Faker<RequestCreateOfferJson>()
            .RuleFor(request => request.Price, f => f.Random.Decimal(1, 100))
            .Generate();

        var offerRepositoryMock = new Mock<IOfferRepository>();
        var loggedUserMock = new Mock<ILoggedUser>();
        loggedUserMock.Setup(i => i.User()).Returns(new User());

        var useCase = new CreateOfferUseCase(loggedUserMock.Object, offerRepositoryMock.Object);

        // Act
        var act = () => useCase.Execute(itemId, request);

        // Assert
        act.Should().NotThrow();
    }
}
