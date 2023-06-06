using CompositionExercise.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CompositionExercise.Entities
{
    internal class Order
    {
        public DateTime Momment { get; set; }
        public OrderStatus Status{ get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }

        public Order()
        {

        }

        public Order(DateTime momment, OrderStatus status, Client client)
        {
            Momment = momment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total(OrderItem item)
        {
            double sum = 0;
            
            foreach(OrderItem i in Items)
            {
                sum += i.Subtotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Order momment: " + Momment);
            sb.AppendLine("Order status: " + Status);
            sb.AppendLine("Client: " + Client.Name + " (" + Client.BirthDate.ToString("dd/MM/yyyy") + ") - " + Client.Email);
            sb.AppendLine("Order Items:");

            foreach(OrderItem i in Items)
            {
                sb.AppendLine(i.Product.Name + ", $" + i.Product.Price.ToString("F2", CultureInfo.InvariantCulture) + ", Quantity: " + i.Quantity + ", Subtotal: $" + i.Subtotal().ToString("F2", CultureInfo.InvariantCulture));
            }

            return sb.ToString();
        }
    }
}
