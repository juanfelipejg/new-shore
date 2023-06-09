using Microsoft.EntityFrameworkCore;
using NewShore.Application.Services.Journeys;
using NewShore.Domain.Serivces.Flights;
using NewShore.Infrastructure.Data;
using NewShore.Infrastructure.Services;
using NewShore.Infrastructure.Wrapper;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString( "Default" );

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper( AppDomain.CurrentDomain.GetAssemblies() );
builder.Services.AddSwaggerGen( options =>
{
	options.CustomSchemaIds( type => type.ToString() );
} );
builder.Services.AddScoped<IJourneyService, JourneyService>();
builder.Services.AddScoped<IFlightsGetter, FlightsGetter>();
builder.Services.AddScoped<IRestClientWrapper, RestClientWrapper>();
builder.Services.AddScoped<INewShoreContext, NewShoreContext>();
builder.Services.AddDbContext<NewShoreContext>( context => context.UseMySql( connectionString, ServerVersion.AutoDetect( connectionString ) ) );

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
