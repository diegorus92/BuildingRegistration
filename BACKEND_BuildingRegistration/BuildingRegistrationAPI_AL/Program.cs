using BuildingRegistrationAPI_DL.Data;
using BuildingRegistrationAPI_BL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BuildingRegistrationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetSection("ConnectionSettings")["ConnectionString"]);
});
builder.Services.AddScoped<DbContext, BuildingRegistrationContext>();


builder.Services.AddScoped<IBuildingService, BuildingService>();
builder.Services.AddScoped<IOccupantService, OccupantService>();
builder.Services.AddScoped<IGarageService, GarageService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();


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


app.UseHttpsRedirection();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
