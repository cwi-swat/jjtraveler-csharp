using System;
using System.Threading;

using dotUnit.Framework;

namespace JJTraveler.Tests
{
	/// <summary>
	/// Summary description for LoggerTest.
	/// </summary>
	public class LoggerTest : VisitorTestCase
	{
		public LoggerTest(string test) : base(test)
		{
		}
		public virtual void testEventTiming() // throws InterruptedException 
		{
			Logger l = new Logger();
			l.log(new Event(null,null));
			Thread.Sleep(100);
			l.log(new Event(null,null));
			Assertion.AssertTrue(l.getElapsedTime() >= 0);
		}
	}
}