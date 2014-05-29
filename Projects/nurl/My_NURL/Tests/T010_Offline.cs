/*
 * Created by SharpDevelop.
 * User: bourdaa
 * Date: 27/05/2014
 * Time: 14:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;

namespace My_NURL
{

	[TestFixture]
	public class T010_Offline
	{
		[Test]
		public void Should_show_the_content_of_a_page()
		{
			var command = new Nurl_command( new string[] {"get","-url","http://fake"}); //votre implémentation
			command.textFromAnURL = "<h1>hello</h1>"; //Offline

			Assert.AreEqual(true, command.isUrlToShow);
		}
		
		[Test]
		public void Content_of_a_page_correctly_show()
		{
			var command = new Nurl_command( new string[] {"get","-url","http://fake"});
			command.textFromAnURL = "<h1>hello</h1>"; //Offline

			var result = command.textFromAnURL;
			
			Assert.That(result, Is.EqualTo("<h1>hello</h1>"));
		}

		[Test]
		public void is_Argument_Correctly_parse()
		{
			var command = new Nurl_command( new string[] {"get","-url","http://fake", "test", "-times", "5", "-avg"}); //votre implémentation
			command.textFromAnURL = "<h1>hello</h1>"; //Offline

			Assert.AreEqual(true, command.isUrlToShow);
			Assert.AreEqual(true, command.isConnectionToCheck);
			Assert.AreEqual(true, command.isAvgOfCheck);
			Assert.AreEqual(5, command.nbTimesToCheck);
			Assert.AreEqual("http://fake", command.urlAddress);
		}

		[Test]
		public void check_connection()
		{
			//given
			var command = new Nurl_command( new string[] {"get","-url","http://fake", "test", "-times", "5", "-avg"});
			
			Assert.AreEqual(typeof(TimeSpan[]), command.checkConnectionNbTimes().GetType());
			Assert.AreEqual(typeof(TimeSpan), command.checkAvgConnectionNbTimes().GetType());
		}
		
		[Test]
		public void save_content_correctly_do()
		{
			
			var command = new Nurl_command(new string[]{});
			string path = "fake.txt";
			command.textFromAnURL = "<h1>hello</h1>";
			command.path_where_save_URL = path;
			command.save_URL();
			
			string textFromAFileOpen = System.IO.File.ReadAllText(path);
			Assert.AreEqual(true, textFromAFileOpen.Contains("<h1>hello</h1>"));
			Assert.AreEqual(false, textFromAFileOpen.Contains("<h1>Bye Bye</h1>"));
			
		}
		
	}
}
