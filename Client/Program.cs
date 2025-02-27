using Microsoft.AspNetCore.SignalR.Client;

class Program
{
    static async Task Main(string[] args)
    {
        // Define the connection to the SignalR hub
        var connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7290/chatHub") // Replace with your SignalR hub URL
            .Build();

        // Handle incoming messages
        connection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            Console.WriteLine($"{user}: {message}");
        });

        // Start the connection
        try
        {
            await connection.StartAsync();
            Console.WriteLine("Connected to SignalR Hub. Waiting for username assignment...");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error connecting to SignalR Hub: {ex.Message}");
            return;
        }

        // Send messages to the hub
        while (true)
        {
            var message = Console.ReadLine();

            try
            {
                await connection.InvokeAsync("SendMessage", message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message: {ex.Message}");
            }
        }
    }
}