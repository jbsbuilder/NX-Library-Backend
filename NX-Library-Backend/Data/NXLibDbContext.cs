using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace NX_Library_Backend.Data
{
    public class NXLibDbContext : IdentityDbContext<ApplicationUser>
    {

    }
}
