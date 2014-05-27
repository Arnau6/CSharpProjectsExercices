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
using My_NURL.Parser;
	
namespace My_NURL.Tests
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
			
			//when
			var result = command.textFromAnURL; //exemple d'implémentation

			//then
			Assert.That(result, Is.EqualTo("<h1>hello</h1>"));
		}
		
		
	}
}
