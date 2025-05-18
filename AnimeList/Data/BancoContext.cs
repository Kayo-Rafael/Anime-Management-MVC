using AnimeUserManager.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimeUserManager.Data;

public class BancoContext : DbContext
{
    public BancoContext(DbContextOptions<BancoContext> options) : base(options)
    {

    }
    public DbSet<UserModel> Users { get; set; }
}
