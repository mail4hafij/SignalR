# SignalR
A super simple chat application using SignalR that maintains the number of clients currently connected to the server and assign username for any new client.
SignalR enables bi-directional communication between the server and clients, allowing the server to instantly push updates to connected clients (e.g., browsers, mobile apps, or desktop apps).

Key Features:
* Real-Time Communication: Enables instant messaging, notifications, and live updates.
* Automatic Connection Management: Handles connection, reconnection, and scaling.
* Multiple Transport Protocols: Uses WebSockets, Server-Sent Events (SSE), or long polling, depending on client support.
* Broadcasting: Send messages to all clients, specific groups, or individual clients.


## How to run locally
There are two projects. 
1. Server - A simple dotnet core empty web application that host the Hub for SignalR.
2. Client - A simple dotnet core console applicaiton that connects to the Server.

Run the Server application first. Run multiple Client instances to mimic multiple chat users.

