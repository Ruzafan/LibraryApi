using Library;
using Library.Features.GetBookDetail.V1;
using Library.Features.GetBooksList;
using Library.Features.GetBooksList.V1;
using Library.Features.GetBooksList.V1.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLogging();
builder.Services.AddFeatures();
builder.Services.AddMongoDb(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Library", Version = "v1" });
}).ConfigureSwaggerGen(options =>
{
    options.CustomSchemaIds(x => x.FullName);
});

builder.Services.AddHttpClient();


builder.Services.AddJwt(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c => 
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library v1"); 
    c.RoutePrefix = "library/swagger"; 
});
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapEndpoints();

app.MapGet("/library/alive", context => Task.CompletedTask);

app.Run();
