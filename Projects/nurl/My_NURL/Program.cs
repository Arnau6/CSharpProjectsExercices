/*
 * Created by SharpDevelop.
 * User: bourdaa
 * Date: 27/05/2014
 * Time: 14:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace My_NURL
{
	class Program
	{
		public static int Main(string[] args)
		{
			if (args.Length < 3)
			{
				Console.WriteLine("Not enough arguments");
				Console.Write("Press any key to continue . . . ");
				Console.ReadKey(true);
				return 1;
			}
			
			var command = new Nurl_command(args);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
			
			return 0;
		}
		
	}
}