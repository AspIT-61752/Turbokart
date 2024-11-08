
using Microsoft.EntityFrameworkCore;
using Turbokart.DataAccess;

namespace Turbokart.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("TurbokartCorsOptions", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            // Add services to the container.

            // Get connection string from appsettings.json
            builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("TurbokartConnection"))
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("TurbokartCorsOptions");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
