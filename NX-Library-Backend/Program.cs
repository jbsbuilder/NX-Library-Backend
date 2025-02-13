using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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
        options.ExampleFilters();
    });
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
builder.Services.AddDbContext<NXLibraryBackend>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("NXLibDbContext")));



var app = builder.Build();




app.Run();


//false;false;
