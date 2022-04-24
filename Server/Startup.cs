using BlazorJWT_Auth.Server.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BlazorJWT_Auth.Server
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextFactory<MyContext>(options =>
            {
                options.UseSqlite($"Data Source=database.db");
            });
            services.AddScoped(p =>
            {
                var context = p.GetRequiredService<IDbContextFactory<MyContext>>().CreateDbContext();
                context.Database.EnsureCreated();

                return context;
            });
        }

        //add constants
        public void ConfigureJWTAuth(IServiceCollection services)
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidAudience = "Constants.Domain",
                        ValidateIssuer = false,
                        ValidIssuer = "Constants.Domain",
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = false,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Constants.JwtKey")),
                    };
                });
        }

        public void ConfigureIdentity(IServiceCollection services)
        {
            services.AddIdentity<User, Role>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<MyContext>()
            .AddDefaultTokenProviders();

        }
    }
}
