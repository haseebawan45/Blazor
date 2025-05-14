using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BookBuzz;
using BookBuzz.Services;
using BookBuzz.Filters;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register services in the correct order to properly resolve dependencies
builder.Services.AddSingleton<IBookService, BookService>();
builder.Services.AddSingleton<BookFilterService>();
// Register ReviewService after IBookService since it depends on it
builder.Services.AddSingleton<IReviewService>(sp => {
    var bookService = sp.GetRequiredService<IBookService>();
    return new ReviewService(bookService);
});

await builder.Build().RunAsync();
