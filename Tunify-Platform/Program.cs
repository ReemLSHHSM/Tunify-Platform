using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Repository.Interfaces;
using Tunify_Platform.Repository.Services;

namespace Tunify_Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
          


/*creating the string connection*/string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
/*for DB*/builder.Services.AddDbContext<TunifyDBContext>(options => options.UseSqlServer(connectionString));

            //Configure the Identity services 
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<TunifyDBContext>();

            builder.Services.AddControllers();//Adding the controller service

            builder.Services.AddTransient<IUsers,UsersServices>();
            builder.Services.AddTransient<IArtists, ArtistsServices>();
            builder.Services.AddTransient<IPlaylist, PlaylistServices>();
            builder.Services.AddTransient<ISongs,SongsServices>();
            builder.Services.AddTransient<IAccounts, AccountsServices>();



            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Tunify API",
                    Version = "v1",
                    Description = "API for managing playlists, songs, and artists in the Tunify Platform"
                });
            });

            var app = builder.Build();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Tunify API v1");
               options.RoutePrefix = "";
            });

            app.MapControllers();
            app.MapGet("/", () => "Hello World!");
   

            app.Run();
        }
    }
}
