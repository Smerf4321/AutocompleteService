using AutocompleteService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Initialize dataset
Autocomplete.Initialize();

app.MapGet("/autocompleteCityName/{scrap}", Autocomplete.AutocompleteWord)
    .WithName("GetAutocompleteCityName");

app.Run();