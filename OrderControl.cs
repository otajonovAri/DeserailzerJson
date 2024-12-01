using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeserailzerJson
{
	internal class OrderControl
	{
		private int idCounter;
		private List<Order> orders;

		public OrderControl()
		{
			orders = new List<Order>();
			idCounter = 0;
		}

		public int AutoId()
		{
			return ++idCounter;
		}

		public void OrderAdding()
		{
			Console.Write("Customer Name: ");
			string cName = Console.ReadLine();

			Console.Write("Total Amount: ");
			decimal cAmount = Convert.ToDecimal(Console.ReadLine());

			Console.Write("Item Name: ");
			string itemName = Console.ReadLine();

			Console.Write("Item Quantity: ");
			int itemQuan = Convert.ToInt32(Console.ReadLine());

			Console.Write("Item Price: ");
			decimal itemPrice = Convert.ToDecimal(Console.ReadLine());

			OrderItem item = new OrderItem
			{
				ItemName = itemName,
				Quantity = itemQuan,
				Price = itemPrice
			};

			Order order = new Order
			{
				OrderId = AutoId(),
				CustomerName = cName,
				TotalAmount = cAmount,
				Items = new List<OrderItem> { item }
			};

			orders.Add(order);
		}

		public void WriteMemoryStream()
		{
			using (MemoryStream ms = new MemoryStream())
			{
				JsonSerializer.Serialize(ms, orders);
				ms.Position = 0;

				string json = Encoding.UTF8.GetString(ms.ToArray());
				Console.WriteLine("Original JSON:\n" + json);

				json = json.Replace("\"Quantity\":2", "\"Quantity\":5");
				Console.WriteLine("\nModified JSON:\n" + json);

				var modifiedBytes = Encoding.UTF8.GetBytes(json);
				using (var modifiedStream = new MemoryStream(modifiedBytes))
				{
					var updatedOrders = JsonSerializer.Deserialize<List<Order>>(modifiedStream);

					Console.WriteLine("\nUpdated Orders:");
					foreach (var order in updatedOrders)
					{
						Console.WriteLine($"Order ID: {order.OrderId}");
						Console.WriteLine($"Customer: {order.CustomerName}");
						Console.WriteLine($"Total Amount: {order.TotalAmount}");

						foreach (var item in order.Items)
						{
							Console.WriteLine($"Item: {item.ItemName}, Quantity: {item.Quantity}, Price: {item.Price}");
						}
					}
				}
			}
		}
	}
}
