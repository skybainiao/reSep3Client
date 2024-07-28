using reSep3Client.Models;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace reSep3Client.Webservices
{
    public class WebSocketService : IAsyncDisposable
    {
        private ClientWebSocket _webSocket;

        public async Task ConnectAsync(string uri)
        {
            _webSocket = new ClientWebSocket();
            await _webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);
            Console.WriteLine($"Connected");
        }

        public async Task SendMessageAsync(ChatMessage chatMessage)
        {
            var jsonMessage = JsonSerializer.Serialize(chatMessage);
            var bytes = Encoding.UTF8.GetBytes(jsonMessage);
            await _webSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
            Console.WriteLine($"Sent message: {jsonMessage}");
        }


        public async Task<string> ReceiveMessageAsync()
        {
            Console.WriteLine($"Receive message");
            var buffer = new byte[1024];
            var result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            return Encoding.UTF8.GetString(buffer, 0, result.Count);
        }
          
        public async Task CloseAsync()
        {
            await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
        }

        public async ValueTask DisposeAsync()
        {
            await CloseAsync();
        }
    }
}
