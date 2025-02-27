using Server.Hubs;



var builder = WebApplication.CreateBuilder(args);
// Add SignalR services
builder.Services.AddSignalR(); 



var app = builder.Build();
app.MapGet("/", () => "SignalR Server is Running!");
// Map the SignalR hub
app.MapHub<ChatHub>("/chatHub");



app.Run();
