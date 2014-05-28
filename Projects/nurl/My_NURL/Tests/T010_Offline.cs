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
			//given
			var command = new Nurl_command( new string[] {"get","-url","http://fake"}); //votre implémentation
			command.textFromAnURL = "<h1>hello</h1>"; //Offline

			//then
			Assert.AreEqual(true, command.isUrlToShow);
		}
		
		[Test]
		public void Content_of_a_page_correctly_show()
		{
			//given
			var command = new Nurl_command( new string[] {"get","-url","http://fake"}); //votre implémentation
			command.textFromAnURL = "<h1>hello</h1>"; //Offline
			
			//when
			var result = command.textFromAnURL; //exemple d'implémentation

			//then
			Assert.That(result, Is.EqualTo("<h1>hello</h1>"));
		}

		[Test]
		public void is_Argument_Correctly_parse()
		{
			//given
			var command = new Nurl_command( new string[] {"get","-url","http://fake", "test", "-times", "5", "-avg"}); //votre implémentation
			command.textFromAnURL = "<h1>hello</h1>"; //Offline

			//then
			Assert.AreEqual(true, command.isUrlToShow);
			Assert.AreEqual(true, command.isConnectionToCheck);
			Assert.AreEqual(true, command.isAvgOfCheck);
			Assert.AreEqual(5, command.nbTimesToCheck);
			Assert.AreEqual("http://fake", command.urlAddress);
			//Assert.AreEqual(true, command.textFromAnURL);
		}
		
	}
}
