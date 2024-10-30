using Checkpoint1GabrielPescarolli.Models;
using Checkpoint1GabrielPescarolli.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Checkpoint1GabrielPescarolli
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Checkpoint2 - Loja de Jogos Online",
                    Version = "v1",
                    Description = "Essa API foi feita para o Checkpoint 2 de .NET e simula uma loja de jogos online",
                    Contact = new OpenApiContact()
                    {
                        Email = "rm554012@fiap.com.br",
                        Name = "Gabriel Pescarolli Galiza - RM554012"
                    }
                });
            });

            builder.Services.AddDbContext<CheckpointDbContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("OracleCheckpointDbContext"));
            });

            builder.Services.AddScoped<Repository<Endereco>>();
            builder.Services.AddScoped<Repository<Usuario>>();
            builder.Services.AddScoped<Repository<Jogo>>();

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