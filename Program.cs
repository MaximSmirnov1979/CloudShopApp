using CloudShopApp.Model;
using CloudShopApp.Service;

var builder = WebApplication.CreateBuilder(args);

// ��������� �������� �� � ���������
builder.Services.AddDbContext<CloudShopDbContext>();

// �������
builder.Services.AddTransient<IOrderServicecs, DbOrderService>();

var app = builder.Build();


// �������: 
// ����������� CRUD-�������� ��� ��������� ��������
// ������� DAO-��������� �������, � ��� �������������
// ������������ �������� ������������*
// ������� ������� ����������� � �������������� ������ CRUD-�
// + ������������� ��������� � ����� dev � �������� �� ������


// �����
app.MapGet("/", () => "pong");
app.MapGet("/ping", () => "pong");


// ������� ����������� ��� ������������ CRUD-��������
app.MapGet("/all", async (HttpContext context, IOrderServicecs service) =>
{
    await context.Response.WriteAsJsonAsync(service.GetAllOrders());
});

app.MapGet("/get-id", async (HttpContext context, IOrderServicecs service) =>
{
    int id = Convert.ToInt32(context.Request.Query["id"]);
    await context.Response.WriteAsJsonAsync(service.GetOrderById(id));
});

// 

// ������ CRUD-��������

app.Run();
