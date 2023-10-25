using N62_HT_Task1.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.Run();

