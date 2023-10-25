using System.Net.WebSockets;
using System.Text;
using Newtonsoft.Json;
using WebSocketManager;
using WebSocketManager.Common;

public class ChatHandler : WebSocketHandler
{
    public ChatHandler(WebSocketConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager)
    {
    }

    public override async Task OnConnected(WebSocket socket)
    {
        await base.OnConnected(socket);
        var message = "Welcome to the chat!";
        await SendMessageAsync(socket, new Message
        {
            Data = message,
            MessageType = MessageType.Text
        });
    }

    public async Task ABC(string str)
    {
        await SendMessageToAllAsync(new Message
        {
            Data = str,
            MessageType = MessageType.Text
        });
    } 

    public override async Task OnDisconnected(WebSocket socket)
    {
        await base.OnDisconnected(socket);
        var message = "A user has left the chat.";
        await SendMessageToAllAsync(new Message
        {
            Data = message,
            MessageType = MessageType.Text
        });
    }
}