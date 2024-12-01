using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeserailzerJson
{
	internal class Order
	{
		public int OrderId { get; set; }
		public string CustomerName { get; set; }
		public decimal TotalAmount { get; set; }
		public List<OrderItem> Items { get; set; }
	}
}
