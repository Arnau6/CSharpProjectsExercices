/*
 * Created by SharpDevelop.
 * User: bourdaa
 * Date: 27/05/2014
 * Time: 14:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace My_NURL.Parser
{
	/// <summary>
	/// Description of Nurl_command.
	/// </summary>
	public class Nurl_command
	{
		public string textFromAnURL { get; set; }
			
			
		public Nurl_command(string[] Args)
		{
			if(Args.Length < 3)
			{
				Console.WriteLine("Not enough arguments");
			}
		}
	}
}
