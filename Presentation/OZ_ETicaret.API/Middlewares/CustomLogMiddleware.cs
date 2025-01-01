using Serilog.Context;

namespace OZ_ETicaret.API.Middlewares
{
    public static class CustomLogMiddleware
    {
        public static void MyCustomMiddlewares(this WebApplication app)
        {
            app.Use((context, next) =>
            {
                string username = context.User?.Identity?.Name ?? "unknownUser";
                LogContext.PushProperty("username", username);

                return next(context);
            });
        }
    }
}
