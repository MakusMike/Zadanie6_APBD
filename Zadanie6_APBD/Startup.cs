using System.Text.Json.Serialization;
using Zadanie6_APBD.Services;

namespace Zadanie6_APBD;

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Zadanie6_APBD.Context;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
        
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => {
            options.UseSqlServer(Configuration.GetConnectionString("Data Source=localhost;Database=master;User Id=sa;Password=StrongPassword1@;Encrypt=false"));
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "APBD v1"));
        }

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}