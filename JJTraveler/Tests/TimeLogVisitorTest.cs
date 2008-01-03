using System;
using dotUnit.Framework;
using System.Threading;

namespace JJTraveler.Tests 
{
	/// <summary>
	/// Summary description for TimeLogVisitorTest.
	/// </summary>
	public class TimeLogVisitorTest : VisitorTestCase
	{
		public TimeLogVisitorTest(string test) : base(test)
		{
		}
		public virtual void testVisitorTiming() //			throws InterruptedException, VisitFailure 
		{
			Logger l = new Logger();
			TimeLogVisitor tlv = new TimeLogVisitor(new Sleep(1),l);
			(new TopDown(new Sequence(tlv, new Sleep(1)))).visit(n0);
			Console.Error.WriteLine("Elapsed: "+tlv.getElapsedTime());
			Console.Error.WriteLine("Consumed: "+tlv.getConsumedTime());
			Assertion.AssertTrue(tlv.getElapsedTime() >= 0);
			Assertion.AssertTrue(tlv.getConsumedTime() >= 0);
			Assertion.AssertTrue(tlv.getElapsedTime() >= tlv.getConsumedTime());
		}

		public class Sleep : IVisitor 
		{
			int sleepTime;
			public Sleep(int i) { sleepTime = i; }
			public virtual IVisitable visit(IVisitable x) 
			{
				try 
				{
					Thread.Sleep(sleepTime);
				} 
				catch (System.Threading.ThreadInterruptedException) 
				{
				}
				return x;
			}
		}

	}
}