using Microsoft.EntityFrameworkCore;
using Zadanie6_APBD.Context;

 var builder = WebApplication.CreateBuilder(args);

 builder.Services.AddEndpointsApiExplorer();
 builder.Services.AddSwaggerGen();
 builder.Services.AddControllers();
 builder.Services.AddDbContext<AppDbContext>(options =>
 {
     options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=localhost;Database=master;User Id=sa;Password=StrongPassword1@;Encrypt=false"));
 });

 var app = builder.Build();

 if (app.Environment.IsDevelopment())
 {
     app.UseSwagger();
     app.UseSwaggerUI();
 }

 app.UseHttpsRedirection();
 app.MapControllers();
 app.Run();

