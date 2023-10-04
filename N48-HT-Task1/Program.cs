using FileBaseContext.Abstractions.Models.FileContext;
using FileBaseContext.Context.Models.Configurations;
using N48_HT_Task1.DataAccess;

var builder = WebApplication.CreateBuilder(args);
var fileContextOptions = new FileContextOptions<AppFileDataContext>(Path.Combine(builder.Environment.ContentRootPath, "Data/Storage"));

builder.Services.AddSingleton<IFileContextOptions<IFileContext>>(fileContextOptions);
builder.Services.AddScoped<IDataContext, AppFileDataContext>(provider =>
{
    var options = provider.GetRequiredService<IFileContextOptions<IFileContext>>();
    var dataContext = new AppFileDataContext(options);
    dataContext.FetchAsync().AsTask().Wait();

    return dataContext;
});
builder.Services.AddScoped<>
