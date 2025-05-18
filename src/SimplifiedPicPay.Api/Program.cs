var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerDocs();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddDataContext(builder.Configuration);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerDocs();
    app.ApplyMigrations();
    app.SeedData();
}
else
{
    app.UseExceptionHandler();
}

app.Run();
