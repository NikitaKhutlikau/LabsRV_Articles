using LabsRV_Articles.Mapping;
using LabsRV_Articles.Models.Domain;
using LabsRV_Articles.Repositories;
using LabsRV_Articles.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LabsRV_Articles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // ������������ �����������
            builder.Services.AddControllers();
                /*.ConfigureApiBehaviorOptions(options =>
                {
                    // ��������� �������� ����������� ���������� ������ ������, ����� �� ��������� JSON
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        var result = new ObjectResult(context.ModelState)
                        {
                            StatusCode = StatusCodes.Status405MethodNotAllowed,
                            ContentTypes = { "application/json" }
                        };


                        var result = new BadRequestObjectResult(context.ModelState);
                        result.ContentTypes.Add("application/json");
                        return result;
                    };
                });*/

            // ������������ AutoMapper � ����� ��������
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // ������������ InMemory-����������� ��� ������ ��������
            builder.Services.AddSingleton<IRepository<Author>, InMemoryRepository<Author>>();
            builder.Services.AddSingleton<IRepository<Article>, InMemoryRepository<Article>>();
            builder.Services.AddSingleton<IRepository<Sticker>, InMemoryRepository<Sticker>>();
            builder.Services.AddSingleton<IRepository<Comment>, InMemoryRepository<Comment>>();

            // ������������ �������
            builder.Services.AddScoped<AuthorService>();
            builder.Services.AddScoped<ArticleService>();
            builder.Services.AddScoped<StickerService>();
            builder.Services.AddScoped<CommentService>();

            var app = builder.Build();

            // ���� ������ �� ������������� �� ������ �������� ��� ���������� ��� ������,
            // ���������� UseStatusCodePages ��� ��������� � ������������ JSON-������ ������ HTML.
            app.UseStatusCodePages(async context =>
            {
                // �������� ����� � ��� ������
                var response = context.HttpContext.Response;
                response.ContentType = "application/json";

                // ����� ����� ��������� ��������� � ����������� �� ����.
                // ��������, ��� 404 � 400 � ���������� ��������������� ����������.
                string message = response.StatusCode switch
                {
                    404 => "Resource not found.",
                    400 => "Bad request.",
                    _ => "An error occurred."
                };

                var result = JsonSerializer.Serialize(new
                {
                    errorMessage = message,
                    errorCode = $"{response.StatusCode}00"
                });

                await response.WriteAsync(result);
            });

            // ���������� ��������� ������ ����� middleware
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    var errorFeature = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
                    if (errorFeature != null)
                    {
                        var ex = errorFeature.Error;

                        if (ex is ArgumentException)
                            context.Response.StatusCode = 400; // Bad Request
                        else if (ex is KeyNotFoundException)
                            context.Response.StatusCode = 404; // Not Found
                        else
                            context.Response.StatusCode = 500; // Internal Server Error

                        context.Response.ContentType = "application/json";
                        var errResponse = new
                        {
                            errorMessage = ex.Message,
                            errorCode = $"{context.Response.StatusCode}00"
                        };
                        await context.Response.WriteAsJsonAsync(errResponse);
                    }
                });
            });


            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            // ����������� ���������� �� ������������� ����� 24110
            app.Urls.Clear();
            app.Urls.Add("http://localhost:24110");

            app.Run();
        }
    }
}
