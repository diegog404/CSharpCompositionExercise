using CompositionExercise.Entities;
using CompositionExercise.Entities.Enums;
using System.Diagnostics;
using System.Globalization;

Console.WriteLine("Enter client data:");

Console.Write("Name: ");
string name = Console.ReadLine();

Console.Write("Email: ");
string email = Console.ReadLine();

Console.Write("Birth Date (DD/MM/YYYY) ");
DateTime bd = DateTime.Parse(Console.ReadLine());
Console.WriteLine();

Client client = new Client(name, email, bd);

Console.WriteLine("Enter order data:");

Console.Write("Status: ");
OrderStatus os = Enum.Parse<OrderStatus>(Console.ReadLine());
Console.WriteLine();

Console.Write("How many items to this order? ");
int N = int.Parse(Console.ReadLine());

Order order = new Order(DateTime.Now, os, client);

OrderItem orderItem = new OrderItem();

for (int i = 1; i <= N; i++)
{
    Console.WriteLine($"Enter #{i} item data");

    Console.Write("Product name: ");
    string prodName = Console.ReadLine();

    Console.Write("Product price: ");
    double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

    Console.Write("Quantity: ");
    int quantity = int.Parse(Console.ReadLine());
    Console.WriteLine();

    Product product = new Product(prodName, price);
    orderItem = new OrderItem(quantity, price, product);

    order.AddItem(orderItem);
}

Console.WriteLine("ORDER SUMMARY");
Console.WriteLine(order);
Console.WriteLine("Total price: " + order.Total(orderItem).ToString("F2", CultureInfo.InvariantCulture));