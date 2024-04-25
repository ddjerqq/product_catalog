using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddUtcDateTimeProvider();
builder.Services.AddEmailProviders();
builder.Services.AddDbContext();
builder.Services.AddJwtAuth();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapSwagger();
app.MapControllers();

app.Run();