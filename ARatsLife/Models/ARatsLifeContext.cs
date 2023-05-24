using Microsoft.EntityFrameworkCore;

namespace ARatsLife.Models
{
  public class ARatsLifeContext : DbContext
  {
    public DbSet<Choice> Choices { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Plotpoint> Plotpoints { get; set; }
    public ARatsLifeContext(DbContextOptions options) : base(options) { }
  }
}