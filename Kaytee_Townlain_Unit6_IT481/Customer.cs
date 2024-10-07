using System;


namespace Kaytee_Townlain_Unit6_IT481
{
	class Customer
	{
		int NumberOfItems;

		public Customer()
		{
			int NumberOfItems = 6;
		}

		public Customer(int items)
		{
			int ClothingItems = items;
			if (ClothingItems == 0)
			{
				NumberOfItems = GetRandomNumber(1, 20);
			}
			else
			{
				NumberOfItems = ClothingItems;
			}
		}

		//Return number of items

		public int getNumberOfItems()
		{
			return NumberOfItems;
		}

		//Random number methods
		private static readonly Random getrandom = new Random();

		public static int GetRandomNumber(int min, int max)
		{
			//https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/lock
			lock (getrandom)
			{
				return getrandom.Next(min, max);
			}
		}
	}
}

