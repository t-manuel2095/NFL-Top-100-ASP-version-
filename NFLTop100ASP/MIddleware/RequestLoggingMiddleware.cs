using System.Diagnostics;

namespace NFLTop100ASP.MIddleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        //Runs on every request, logs HTTP method, path, and how long it took (in ms). Good practice for learning the middleware pipeline.
        public async Task InvokeAsync (HttpContext context)
        {
            var stopWatch = Stopwatch.StartNew();

            await _next(context);

            stopWatch.Stop();

            _logger.LogInformation(
                "{Method} {Path} responded in {ElasedMs} ms with {StatusCode}",
                context.Request.Method,
                context.Request.Path,
                stopWatch.ElapsedMilliseconds,
                context.Response.StatusCode);
        }
    }
}
