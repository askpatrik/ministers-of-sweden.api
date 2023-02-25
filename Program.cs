using Microsoft.EntityFrameworkCore;
using ministers_of_sweden.api.Data;

var builder = WebApplication.CreateBuilder(args);



//Add database support
builder.Services.AddDbContext<MinistersOfSwedenContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Load data into database

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
var context = services.GetRequiredService<MinistersOfSwedenContext>();

    await context.Database.MigrateAsync();
    await SeedData.LoadPartyData(context);
    await SeedData.LoadDepartmentData(context);
    await SeedData.LoadAcademicFieldsData(context);
    await SeedData.LoadMinisterData(context);

}
catch (Exception ex)
{
Console.WriteLine(ex.Message);
throw;
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Det finns en wwwroot katalog
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
