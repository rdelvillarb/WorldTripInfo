var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(builder=>builder.WithOrigins("*"));
}

app.UseHttpsRedirection();


app.MapGet("/tripInfo", () =>
{
    var tripList = new List<TripInfo>
        {
            new(1, "Paris", "paris.jpg", 1599m ),
            new(2, "New York", "newyork.jpg", 2099),
            new(3, "Tokyo", "tokyo.jpg", 2999)           
        };
    return tripList;
})
.WithName("GetTripInfo")
.WithOpenApi();

app.Run();

record TripInfo(int TripId,String Location, String PhotoUrl, decimal Price);
