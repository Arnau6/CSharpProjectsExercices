/*
 * Created by SharpDevelop.
 * User: bourdaa
 * Date: 27/05/2014
 * Time: 14:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace My_NURL
{
	/// <summary>
	/// Description of Nurl_command.
	/// </summary>
	public class Nurl_command
	{
		public bool isUrlToShow { get; set; }
		public bool isConnectionToCheck { get; set; }
		public bool isAvgOfCheck { get; set; }
		
		public int nbTimesToCheck  { get; set; }
		
		public string urlAddress { get; set; }
		public string textFromAnURL { get; set; }
			
		public Nurl_command(string[] Args)
		{
			if(Args.Length < 3)
				Console.WriteLine("Not enough arguments");
			
			isUrlToShow = isConnectionToCheck = isAvgOfCheck = false;
			nbTimesToCheck = 1;
			
			for(int i=0; i < Args.Length; i++)
			{
				if(Args[i].Equals("get"))
					isUrlToShow = true;
				
				if(Args[i].Equals("test"))
					isConnectionToCheck = true;
				
				if(Args[i].Equals("-url"))
					urlAddress = Args[i+1];
				
				if(Args[i].Equals("-times"))
					nbTimesToCheck = int.Parse(Args[i+1]);
				
				if(Args[i].Equals("-avg"))
					isAvgOfCheck = true;
				
			}
			
		}
		
		void parseArgs(string[] args)
		{
			
		}
	}
}
