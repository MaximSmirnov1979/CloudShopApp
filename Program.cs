using CloudShopApp.Model;
using CloudShopApp.Service;

var builder = WebApplication.CreateBuilder(args);

// добавляем контекст БД в контейнер
builder.Services.AddDbContext<CloudShopDbContext>();

// сервисы
builder.Services.AddTransient<IOrderServicecs, DbOrderService>();

var app = builder.Build();


// ЗАДАНИЕ: 
// Реализовать CRUD-операции для созданной сущности
// Сделать DAO-интерфейс сервиса, и его имплементацию
// Использовать инъекцию зависимостей*
// Сделать простые контроллеры и протестировать методы CRUD-а
// + зафиксировать изменения в ветке dev и запушить на сервер


// пинги
app.MapGet("/", () => "pong");
app.MapGet("/ping", () => "pong");


// простые контроллеры для тестирования CRUD-операций
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

// ПРОЧИЕ CRUD-операции

app.Run();
