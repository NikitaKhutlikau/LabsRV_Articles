using LabsRV_Discussion.Repositories;
using MongoDB.Driver;

namespace LabsRV_Discussion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container

            // Настройка MongoDB
            builder.Services.AddSingleton<IMongoClient>(new MongoClient(builder.Configuration["MongoDb:ConnectionString"]));
            builder.Services.AddScoped<MongoCommentRepository, MongoCommentRepository>();

            // Настройка порта
            builder.WebHost.UseUrls("http://localhost:24130");

            var app = builder.Build();


            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            //app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
