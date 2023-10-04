using N45_HT_Task1.Models;

var user = new List<User>()
{
    new User(1,"Jonibek"),
    new User(2,"Konibek"),
    new User(3,"Jabbor"),
    new User(4,"Gani"),
};
var products = new List<Product>()
{
    new Product("olma",2000),
    new Product("kola",2000),
    new Product("banan",2000),
    new Product("olcha",2000),
};
var orders = new List<Order>()
{
    new Order(2000, 1),
    new Order(3000, 2),
    new Order(4000, 3),
    new Order(5000, 4),
};
var orderProducts = new List<OrderProduct>()
{
    new OrderProduct(1,2,3,4),
    new OrderProduct(1,2,3,4),
    new OrderProduct(1,2,3,4),
    new OrderProduct(1,2,3,4),
};
var query =
    from users in user
    join order in orders on users.Id equals order.UserID
    join orderProduct in orderProducts on order.Id equals orderProduct.OrderId
    join product in products on orderProduct.ProductId equals product.Id
    where users.Id == UserID
    select product.Name;

query.ToList().ForEach(Console.WriteLine);