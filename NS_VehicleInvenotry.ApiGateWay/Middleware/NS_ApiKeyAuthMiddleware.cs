namespace NS_VehicleInvenotry.ApiGateWay.Middleware
{
    public sealed class NS_ApiKeyAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private const string API_KEY_HEADER = "X-Api-Key";
        private const string VALID_API_KEY = "This_is_Nirav_Saxena_Super_Key_123";

        public NS_ApiKeyAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(API_KEY_HEADER, out var key)
                || key != VALID_API_KEY)
            {
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(new
                {
                    error = "Unauthorized",
                    message = "Missing or invalid API key."
                });
                return;
            }

            await _next(context);
        }
    }
}
