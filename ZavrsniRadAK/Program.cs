using Microsoft.EntityFrameworkCore;
using ZavrsniRadAK.Controllers;
using ZavrsniRadAK.Data;

namespace ZavrsniRadAK
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var customCorsPolicy = "_customCorsPolicy";

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(customCorsPolicy,
                    builder =>
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                );

            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<GuildLeaderboard_ZavrsniContext>
                (
                    options => options.UseSqlServer(connectionString)
                ) ;

            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            
                app.UseSwagger();
                app.UseSwaggerUI();

                        if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                };

            
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors(customCorsPolicy);
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}