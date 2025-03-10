using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Context;

public class RememberNowContext : DbContext
{
    public RememberNowContext(DbContextOptions<DbContext> options) : base(options) { }

    public DbSet<Card> Cards { get; set; }
    public DbSet<CardContent> CardContents { get; set; }

}