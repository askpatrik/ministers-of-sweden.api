using Microsoft.EntityFrameworkCore;
using ministers_of_sweden.api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Konfigurera program cs klass att aktivera att använda databasen och generera DI möjlighet så vi kan använda det i controllers. 

//Add database support

builder.Services.AddDbContext<MinistersOfSwedenContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
});

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

app.UseAuthorization();

app.MapControllers();

app.Run();
