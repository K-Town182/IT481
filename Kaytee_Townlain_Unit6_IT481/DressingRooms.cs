using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Kaytee_Townlain_Unit6_IT481
{
	class DressingRooms
	{
		int rooms;
		//https://learn.microsoft.com/en-us/dotnet/api/system.threading.semaphore?view=net-7.0
		Semaphore semaphore;
		long waitTimer;
		long runTimer;

		public DressingRooms()
		{
			rooms = 3;
			semaphore = new Semaphore(rooms, rooms);
		}

		public DressingRooms(int r)
		{
			rooms = r;
			//Set the semaphore object
			semaphore = new Semaphore(rooms, rooms);
		}

		public async Task RequestRoom(Customer c)
		{
			//https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch?view=net-7.0
			Stopwatch stopWatch = new Stopwatch();
			//Waiting thread
			Console.WriteLine("Customer is wating");

			//Start timer
			stopWatch.Start();
			//https://learn.microsoft.com/en-us/dotnet/api/system.threading.waithandle.waitone?view=net-7.0#system-threading-waithandle-waitone
			semaphore.WaitOne();
			//Stop wait timer
			stopWatch.Stop();
			//Get time elapsed for waiting
			waitTimer += stopWatch.ElapsedTicks;

			int roomWaitTime = GetRandomNumber(1, 3);
			//Start timer
			stopWatch.Start();
			//Get elpased run time
			runTimer += stopWatch.ElapsedTicks;

			Console.WriteLine("Customer finished trying on items in room");
			semaphore.Release();
		}

		public long getWaitTime()
		{
			return waitTimer;
		}

		public long getRunTime()
		{
			return runTimer;
		}

		//Random number methods
		private static readonly Random getrandom = new Random();

		public static int GetRandomNumber(int min, int max)
		{
			lock (getrandom)
			{
				return getrandom.Next(min, max);
			}
		}
	}
}
