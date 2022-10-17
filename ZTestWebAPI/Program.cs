
//Add comment
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging(); //Подключение к браузеру для отладки Blazor
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseBlazorFrameworkFiles();       //Добавляем поддержку инфраструктуры Blazor
app.UseStaticFiles();                //Статические файлы нужны для работы стилей и скриптов
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("index.html"); //Если адрес непонятен, то перенаправляем на приложение Blazor
app.Run();

