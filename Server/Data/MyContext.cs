using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorJWT_Auth.Server.Data
{
    public class MyContext : IdentityDbContext<User, Role, long>
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }
    }
}
