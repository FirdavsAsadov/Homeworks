namespace FileExplorer.Api.Configurations
{
    public static partial class HostConfigurations
    {
        public static WebApplicationBuilder Configure(this WebApplicationBuilder builder)
        {
            builder.AddAutoMapper();
            builder.Services();
            builder.AddDevTools();
            builder.AddExposers();
            return builder;
        }
        public static async ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
        {
            app.UseDevTools();
            app.UseCors();
            app.MapControllers();
            return app;
        }
    }
}
