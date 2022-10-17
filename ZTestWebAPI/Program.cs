
//Add comment
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging(); //����������� � �������� ��� ������� Blazor
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseBlazorFrameworkFiles();       //��������� ��������� �������������� Blazor
app.UseStaticFiles();                //����������� ����� ����� ��� ������ ������ � ��������
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("index.html"); //���� ����� ���������, �� �������������� �� ���������� Blazor
app.Run();

