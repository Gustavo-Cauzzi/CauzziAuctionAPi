using CauzziAuction.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CauzziAuction.API.Repositories;

public class CauzziAuctionDbContext : DbContext
{
    public CauzziAuctionDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; }
}
