namespace TestWebApi.Web.Middlewares
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string APIKEY = "ComputersApiKey";
        
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(APIKEY, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Please provide a valid API Key.");
                return;
            }

            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<Guid>(APIKEY);

            if (!Guid.TryParse(extractedApiKey, out var extractedAsGuid) || !apiKey.Equals(extractedAsGuid))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("You are not authorized to access this content.");
                return;
            }

            await _next(context);
        }
    }
}
