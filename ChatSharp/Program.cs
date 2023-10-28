using WebSocketManager;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddWebSocketManager()
    .AddSingleton<WebSocketConnectionManager>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

var serviceProvider = app.Services;
        
app.UseWebSockets();
app.MapWebSocketManager("/chat", serviceProvider.GetService<ChatHandler>());

app.Run();