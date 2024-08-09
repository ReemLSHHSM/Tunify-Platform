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
            

            builder.Services.AddControllers();//Adding the controller service

            builder.Services.AddTransient<IUsers,UsersServices>();
            builder.Services.AddTransient<IArtists, ArtistsServices>();
            builder.Services.AddTransient<IPlaylist, PlaylistServices>();
            builder.Services.AddTransient<ISongs,SongsServices>();

            var app = builder.Build();
            app.MapControllers();



            app.MapGet("/", () => "Hello World!");
   

            app.Run();
        }
    }
}
