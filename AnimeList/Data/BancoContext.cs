using AnimeList.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimeList.Data;

public class BancoContext : DbContext
{
    public BancoContext(DbContextOptions<BancoContext> options) : base(options)
    {

    }
    public DbSet<AnimeModel> Animes { get; set; }
}
