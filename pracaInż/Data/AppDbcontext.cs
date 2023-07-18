using Microsoft.EntityFrameworkCore;

namespace pracaInż.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions options) : base(options) { }


    }
}
