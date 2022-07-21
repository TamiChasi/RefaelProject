using Application.MiddleWares;
using BL;
using DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IViewDevicesBL, ViewDevicesBL>();
builder.Services.AddSingleton<IViewDevicesDAL, ViewDevicesDAL>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHandlerErrorsMiddleware(); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
