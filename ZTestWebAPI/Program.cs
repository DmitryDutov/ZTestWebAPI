
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
    app.UseWebAssemblyDebugging();   //����������� � �������� ��� ������� Blazor
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseBlazorFrameworkFiles();       //��������� ��������� �������������� Blazor
app.UseStaticFiles();                //����������� ����� ����� ��� ������ ������ � ��������
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("index.html"); //���� ����� ���������, �� �������������� �� ���������� Blazor
app.Run();

