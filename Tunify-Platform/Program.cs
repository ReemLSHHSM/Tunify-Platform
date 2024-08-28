using Humanizer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Data;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repository.Interfaces;
using Tunify_Platform.Repository.Services;

namespace Tunify_Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Creating the connection string
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Configure the DbContext for the database
            builder.Services.AddDbContext<TunifyDBContext>(options => options.UseSqlServer(connectionString));

            // Configure the Identity services 
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<TunifyDBContext>();

            // IdentityUser: This is the class that represents a user in the Identity system.
            // It includes properties like UserName, Email, PasswordHash, etc.
            // IdentityRole: This is the class that represents a role. A role is a way to group users together with specific permissions.

            builder.Services.AddControllers(); // Adding the controller service

            // Adding repository services
            builder.Services.AddTransient<IUsers, UsersServices>();
            builder.Services.AddTransient<IArtists, ArtistsServices>();
            builder.Services.AddTransient<IPlaylist, PlaylistServices>();
            builder.Services.AddTransient<ISongs, SongsServices>();
            builder.Services.AddTransient<IAccounts, AccountsServices>();

            // Swagger Configuration
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Tunify API",
                    Version = "v1",
                    Description = "API for managing playlists, songs, and artists in the Tunify Platform"
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Please enter user token below."
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            // JWT Authentication Configuration
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = JwtTokenService.ValidateToken(builder.Configuration);
            });

            var app = builder.Build();

            // Middleware Configuration
            app.UseAuthentication();
            app.UseAuthorization();

            // Swagger Middleware
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "api/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Tunify API v1");
                options.RoutePrefix = "musicAPI"; // Set as needed
            });

            app.MapControllers();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
