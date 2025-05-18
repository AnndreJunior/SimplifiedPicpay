namespace SimplifiedPicPay.Api.Extentions;

public static class WebApplicationExtensions
{
    public static WebApplication UseSwaggerDocs(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}
