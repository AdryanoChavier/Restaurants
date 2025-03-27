using Restaurants.API.Middlewares;
using Restaurants.Infrastructure.Seeders;
using Restaurants.IoC;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ErroHandlingMiddle>();

builder.Services.AddInfraestructure(builder.Configuration);
builder.Host.UseSerilog((context, configuration) =>
    configuration .ReadFrom.Configuration(context.Configuration)   
);

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();

//await seeder.Seed();

// Configure the HTTP request pipeline.
app.UseMiddleware<ErroHandlingMiddle>();

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
