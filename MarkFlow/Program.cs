using MarkFlow.Components;
using MarkFlow.FileService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
/*
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
*/
if (args.Length != 1)
{
    throw new ArgumentException("You must provide a path to a file.");
}

var path = args[0];

builder.Services.AddScoped<IFileService>(provider => new FileService(path));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


//app.MapRazorComponents<App>()
//    .AddInteractiveServerRenderMode()
//    .AddInteractiveWebAssemblyRenderMode();

app.Run();
