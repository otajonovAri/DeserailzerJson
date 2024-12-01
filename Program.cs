namespace DeserailzerJson
{
   internal class Program
   {
      static void Main(string[] args)
      {
			OrderControl control = new OrderControl();
			bool exit = false;

			while (!exit)
			{
				Console.WriteLine("\n--- Order Management System ---");
				Console.WriteLine("1. Add New Order");
				Console.WriteLine("2. Display Orders (Serialized JSON)");
				Console.WriteLine("3. Exit");
				Console.Write("Choose an option: ");
				string choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						control.OrderAdding();
						break;
					case "2":
						control.WriteMemoryStream();
						break;
					case "3":
						exit = true;
						Console.WriteLine("Exiting... Goodbye!");
						break;
					default:
						Console.WriteLine("Invalid choice. Please try again.");
						break;
				}
			}
		}
	}
}
