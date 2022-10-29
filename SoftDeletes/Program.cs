

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    using var context = new LibraryContext();
    return context.Book.ToList();
});

app.Run();
