using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace CSharp6.Networking
{
    public class CustomMessageHandler : HttpClientHandler
    {
        private string _message;

        public CustomMessageHandler(string message)
        {
            _message = message;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            WriteLine($"In CustomMessageHandler, Message: {_message}");

            if (_message == "error")
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);

                return Task.FromResult<HttpResponseMessage>(response);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
