using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Serilog;
using talentX.WebScrapper.LayOff.Repositories.Classes;
using talentX.WebScrapper.LayOff.Repositories.Contracts;
using talentX.WebScrapper.LayOff.Repositories.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var logger = new LoggerConfiguration().MinimumLevel.Information()
    .WriteTo.File("log/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
Log.Logger = logger;
builder.Host.UseSerilog();

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("talentX.WebScrapper.LayOff.Api"));
});


builder.Services.AddScoped<IScrapDataRepo, ScrapDataRepo>();
builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]);

var app = builder.Build();

// Configure the HTTP request pipeline.


    app.UseSwagger();
    app.UseSwaggerUI();


var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<DataContext>();
try
{
    context.Database.Migrate();
    DbInitializer.Initialize(context);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message, "A problem occured during migration");
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(opt =>
{
    app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});

app.Run();
