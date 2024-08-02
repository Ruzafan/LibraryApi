var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddFeatures();
builder.Services.AddMongoDb(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen().ConfigureSwaggerGen(options =>
{
    options.CustomSchemaIds( x=> x.FullName );
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("localhost",
        policy =>
        {
            policy.AllowAnyOrigin();
        });
});
builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("localhost");
app.UseAuthorization();
app.MapControllers();

app.Run();
