
using Microsoft.EntityFrameworkCore;
using ZTestWebDAL.Context;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddDbContext<ZTestDb>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"))
    );

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();   //Подключение к браузеру для отладки Blazor
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseBlazorFrameworkFiles();       //Добавляем поддержку инфраструктуры Blazor
app.UseStaticFiles();                //Статические файлы нужны для работы стилей и скриптов
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("index.html"); //Если адрес непонятен, то перенаправляем на приложение Blazor
app.Run();

