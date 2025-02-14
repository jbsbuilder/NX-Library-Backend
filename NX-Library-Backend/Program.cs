using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NX_Library_Backend.Data;
using NXLibraryBackend.Data;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "NX_Library_Backend", Version = "v1" });
        options.ExampleFilters(); // Register the example filters
    });

// Register the necessary services for Swashbuckle.AspNetCore.Filters
builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

//builder.Services.AddAuthorization();
//builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
//    .AddEntityFrameworkStores<NXLibDbContext>();

builder.Services.AddDbContext<NXLibDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("NXLibDbContext")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

//app.UseAuthetication();
//app.UseAuthorization

app.MapControllers();

app.Run();
