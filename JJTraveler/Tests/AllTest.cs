using System;
using dotUnit.Framework;

namespace JJTraveler.Tests
{
	/// <summary>
	/// Summary description for AllTest.
	/// </summary>
	public class AllTest : VisitorTestCase
	{
		public AllTest(string test) : base(test)
		{
		}

		public virtual void testAll() 
		{
			Identity id = new Identity();
			All all = new All(logVisitor(id));
			Logger expected = new Logger(id, new IVisitable[] { n1, n2 });
			try 
			{
				IVisitable nodeReturned = all.visit(n0);
				Assertion.AssertEquals(expected, logger);
				Assertion.AssertEquals(n0, nodeReturned);
			} 
			catch (VisitFailure) 
			{
				Assertion.Fail("VisitFailure should not occur!");
			}
		}
	}
}
