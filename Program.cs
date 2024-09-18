using Checkpoint1GabrielPescarolli.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Checkpoint1GabrielPescarolli
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CheckpointDbContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("OracleCheckpointDbContext"));
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}