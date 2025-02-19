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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BookAuthor>()
                .HasMany(e => e.Book)
                .WithOne(e => e.BookAuthor)
                .HasForeignKey(e => e.AuthorId)
                .IsRequired(false);
        }
        public DbSet<Book> Books { get; set; }
        //public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<Models.BookAuthor> BookAuthor { get; set; } = default!;
    }
}