
using Bogus;
using CauzziAuction.API.Contracts;
using CauzziAuction.API.Entities;
using CauzziAuction.API.Enums;
using CauzziAuction.API.UseCases.Auctions.GetCurrent;
using FluentAssertions;
using Moq;
using Xunit;

namespace UseCases.Test.Auction.GetCurrent;
public class GetCurrentAuctionUseCaseTest
{
    [Fact]
    public void Success()
    {
        // AAA = Arrenge, Act, Assert
        // Arrenge
        var entity = new Faker<CauzziAuction.API.Entities.Auction>()
            .RuleFor(auction => auction.Id, f => f.Random.Number(1, 100))
            .RuleFor(auction => auction.Name, f => f.Lorem.Word())
            .RuleFor(auction => auction.Starts, f => f.Date.Past())
            .RuleFor(auction => auction.Ends, f => f.Date.Future())
            .RuleFor(auction => auction.Items, (f, fakeEntity) => new List<Item> {
                new Item { 
                    Id = f.Random.Number(1, 100),
                    Name = f.Commerce.ProductName(),
                    Brand = f.Commerce.Department(),
                    BasePrice = f.Random.Decimal(60, 1000),
                    Condition = f.PickRandom<Condition>(),
                    AuctionId = fakeEntity.Id
                }
            }).Generate();

        var mock = new Mock<IAuctionRepository>();
        mock.Setup(i => i.GetCurrent()).Returns(entity);
        var useCase = new GetCurrentAuctionUseCase(mock.Object);
        
        // Act
        var auction = useCase.Execute();

        // Assert
        auction.Should().NotBeNull();
        auction.Id.Should().Be(entity.Id);
        auction.Name.Should().Be(entity.Name);
    }
}
