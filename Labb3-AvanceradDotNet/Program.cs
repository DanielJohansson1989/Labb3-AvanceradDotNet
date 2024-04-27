
using Labb3_AvanceradDotNet.Data;
using Labb3_AvanceradDotNet.Services;
using Labb3Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_AvanceradDotNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ILabb3<Person>, PersonRepository>();
            builder.Services.AddScoped<ILabb3<Interest>, InterestRepository>();
            builder.Services.AddScoped<ILabb3<PersonalInterest>, PersonalInterestRepository>();
            builder.Services.AddScoped<ILabb3<Link>, LinkRepository>();

            builder.Services.AddControllers().AddJsonOptions(o => 
            { 
                o.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles; 
            });

            builder.Services.AddDbContext<Labb3DbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
