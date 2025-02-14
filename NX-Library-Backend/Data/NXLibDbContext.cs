using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using NX_Library_Backend.Data;

namespace NXLibraryBackend.Data
{
    public class NXLibDbContext : IdentityDbContext<ApplicationUser>
    {
        public NXLibDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions) { }

        public DbSet<Book> Books { get; set; }
    }
}