using API.Entity.Repository;
using API.Entity.Service;
using API.Interface.Reporitory;
using API.Interface.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Reflection;

namespace API
{
    public static class Services
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<ICEPService, CEPService>();

            services.AddScoped<IContaRepository, ContaRepository>();

            services.AddScoped<IContaService, ContaService>();

            string directory = Directory.GetCurrentDirectory();
            string connectionString = $"Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;AttachDbFileName={directory}\\Database\\Banco.mdf;";

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
