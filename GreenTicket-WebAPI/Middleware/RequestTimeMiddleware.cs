using System.Diagnostics;

namespace GreenTicket_WebAPI.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private readonly ILogger<RequestTimeMiddleware> _logger;
        private readonly IConfiguration _config;

        private Stopwatch _stopwatch { get; set; }
        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger, IConfiguration config)
        {
            _stopwatch = new Stopwatch();
            _logger = logger;
            _config = config;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopwatch.Start();
            await next.Invoke(context);
            _stopwatch.Stop();
            var elapsedMillisecnds = _stopwatch.ElapsedMilliseconds;
            int logFromMs = Int32.Parse(_config["AppSettings:MinRequestTimeLog"]!);
            if (elapsedMillisecnds > logFromMs)
            {
                var message = $"Request {context.Request.Method} at {context.Request.Path} took {elapsedMillisecnds} ms.";
                _logger.LogInformation(message);
            }
        }
    }
}
