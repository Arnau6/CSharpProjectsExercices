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
		public bool isUrlToSave { get; set; }
		public bool isConnectionToCheck { get; set; }
		public bool isAvgOfCheck { get; set; }
		
		public int nbTimesToCheck  { get; set; }
		
		public string urlAddress { get; set; }
		public string textFromAnURL { get; set; }
		public string path_where_save_URL { get; set; }
		
		public Nurl_command(string[] Args)
		{
			if(Args.Length < 3)
				Console.WriteLine("Not enough arguments");
			
			isUrlToShow = isConnectionToCheck = isAvgOfCheck = isUrlToSave = false;
			nbTimesToCheck = 1;
			
			for(int i=0; i < Args.Length; i++)
			{
				if(Args[i].Equals("get"))
					isUrlToShow = true;
				
				if(Args[i].Equals("test"))
					isConnectionToCheck = true;
				
				if(Args[i].Equals("-url")
				   && i+1  < Args.Length)
				{
					urlAddress = Args[i+1];
					continue;
				}
				
				if(Args[i].Equals("-times")
				   && i+1  < Args.Length)
				{
					nbTimesToCheck = int.Parse(Args[i+1]);
					continue;
				}
				
				if(Args[i].Equals("-save")
				   && i+1  < Args.Length)
				{
					path_where_save_URL = Args[i+1];
					isUrlToSave = true;
					continue;
				}
				
				if(Args[i].Equals("-avg"))
					isAvgOfCheck = true;
			}
			
			
			if(isUrlToShow)
				update_textFromAnURL();
			
			if(isConnectionToCheck && !isAvgOfCheck)
				checkConnectionNbTimes();
			
			else if(isAvgOfCheck)
				checkAvgConnectionNbTimes();
			
			if(isUrlToSave)
				save_URL();
				
		}
		
		public void update_textFromAnURL()
		{
			if(urlAddress != null)
			{
				textFromAnURL = "<h1>hello</h1>"; //Offline
				//Console.ReadKey(true);
			}
			else
				Console.WriteLine("Error");
		}
		
		public TimeSpan[] checkConnectionNbTimes()
		{
			TimeSpan[] check_times_to_connect;
			
			if(isConnectionToCheck == true)
				check_times_to_connect = new TimeSpan[nbTimesToCheck];
			
			else
				return new TimeSpan[0];
			
			for(int i =0; i < nbTimesToCheck; i++)
			{
				var start_tick = DateTime.Now;
				update_textFromAnURL();
				TimeSpan difftime = (DateTime.Now - start_tick);
				
				check_times_to_connect[i] = difftime;
				Console.WriteLine(check_times_to_connect[i]);
			}
			return check_times_to_connect;
		}
		
		public TimeSpan checkAvgConnectionNbTimes()
		{
			var checks = checkConnectionNbTimes();
			var totalCheks = 0.0;
			
			for(int i = 0; i>checks.Length; i++)
				totalCheks += checks[i].TotalMilliseconds;
			
			var avgTimes = TimeSpan.FromMilliseconds(totalCheks / checks.Length);

			return avgTimes;
		}
		
		public void save_URL()
		{
			System.IO.StreamWriter file = new System.IO.StreamWriter(path_where_save_URL);
			file.WriteLine(textFromAnURL);
			file.Close();
		}
	}
}
