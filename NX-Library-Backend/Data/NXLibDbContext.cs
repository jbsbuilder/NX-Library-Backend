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

            builder
                .Entity<Author>()
                .HasMany(b => b.Book)
                .WithOne(b => b.BookAuthor)
                .HasForeignKey(b => b.AuthorId)
                .IsRequired(false);
        }

        public DbSet<Vendor> Vendor { get; set; } = default!;
        public DbSet<PurchaseOrder> PONumber { get; set; } = default!;
        public DbSet<PurchaseOrderDetail> PODetail { get; set; } = default!;
        public DbSet<Book> Books { get; set; } = default!;
        public DbSet<Author> BookAuthor { get; set; } = default!;
    }
}
