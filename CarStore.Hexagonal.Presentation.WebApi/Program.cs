using CarStore.Hexagonal.Application;
using CarStore.Hexagonal.Persistence.Postgres;
using CarStore.Hexagonal.Presentation.WebApi.Middleware;
using CarStore.Hexagonal.Presentation.WebApi.SwaggerTests;

namespace CarStore.Hexagonal.Presentation.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.AddInfrastructureServices();
            builder.AddApplicationServices();
            builder.Services.AddControllers();
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new() { Title = "CarStore API", Version = "v1" });
                options.OperationFilter<GenericTestOperationFilter>();
            });

            var app = builder.Build();

            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseExceptionHandler(o => { });
            app.UseHttpsRedirection();

            app.MapControllers();
            app.Run();
        }
    }
}
