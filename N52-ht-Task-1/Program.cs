using FileBaseContext.Context.Models.Configurations;
using N52_ht_Task_1.DataAccess;
using N52_ht_Task_1.Models;
using N52_ht_Task_1.Services;
using N52_ht_Task_1.Services.Interfeys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>()
    .AddScoped<IAccountService, AccountService>()
    .AddScoped<IEmailSenderService, EmailSenderService>()
    .AddSingleton<AccountEventstore>();
builder.Services.AddSingleton<IDataContext, AppFileContext>(_ =>
{
    var options = new FileContextOptions<AppFileContext>
    {
        StorageRootPath = Path.Combine(builder.Environment.ContentRootPath, "Data", "DataStorage")
    };

    var context = new AppFileContext(options);
    context.FetchAsync().AsTask().Wait();
    return context;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
