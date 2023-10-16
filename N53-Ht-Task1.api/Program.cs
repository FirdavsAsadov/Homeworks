using FileBaseContext.Context.Models.Configurations;
using N53_Ht_Task1.api.DataAccess;
using N53_Ht_Task1.api.Interfeys;
using N53_Ht_Task1.api.Models;
using N53_Ht_Task1.api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUserService, UserService>()
    .AddSingleton<IOrderService, OrderService>()
    .AddSingleton<IBonusService, BonusService>()
    .AddSingleton<INotificationService, TelegramSenderService>()
    .AddSingleton<INotificationService, SmsSenderService>()
    .AddSingleton<INotificationService, EmailSenderService>()
    .AddSingleton<UserPromotionService>()
    .AddSingleton<UserBonusService>()
    .AddSingleton<BonusAchievedEvent>()
    .AddSingleton<OrderCreatedEvent>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
