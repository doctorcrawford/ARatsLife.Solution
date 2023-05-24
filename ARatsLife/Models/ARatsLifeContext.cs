using Microsoft.EntityFrameworkCore;

namespace ARatsLife.Models
{
  public class ARatsLifeContext : DbContext
  {
    public ARatsLifeContext(DbContextOptions options) : base(options) { }
  }
}