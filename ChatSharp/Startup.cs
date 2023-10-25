using WebSocketManager;

namespace ChatSharp;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddWebSocketManager()
            .AddSingleton<WebSocketConnectionManager>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseStaticFiles();
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        

        var serviceProvider = app.ApplicationServices;
        
        app.UseWebSockets();
        app.MapWebSocketManager("/chat", serviceProvider.GetService<ChatHandler>());
    }
}