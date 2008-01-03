using System;
using dotUnit.Framework;
namespace JJTraveler.Tests
{
	/// <summary>
	/// Summary description for FailTest.
	/// </summary>
	public class FailTest : VisitorTestCase
	{
		public FailTest(string test) : base(test)
		{
		}

		public virtual void testFail() 
		{
			try 
			{
				(new Fail()).visit(n0);
				Assertion.Fail();
			}
			catch(VisitFailure) 
			{
				Logger expected = new Logger();
				Assertion.AssertEquals(expected, logger);
			}
		}
	}
}
