
using DAL;
using DAL.Entities;
using DAL.Repositories;
using KYC360SecondStageInterview.Services;

namespace KYC360SecondStageInterview
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
            builder.Services.AddScoped<IRepository<Address>, AddressRepository>();
            builder.Services.AddScoped<IRepository<Entity>, EntityRepository>();
            builder.Services.AddScoped<ICrudService<Entity>, EntityService>();
            builder.Services.AddScoped<IRepository<Entity>, EntityRepository>();
            builder.Services.AddScoped<IRepository<Address>, AddressRepository>();
            builder.Services.AddScoped<LocalDbContext>(i => new LocalDbContext("DevDB"));


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
