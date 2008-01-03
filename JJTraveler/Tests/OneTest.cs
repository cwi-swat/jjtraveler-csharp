using System;
using dotUnit.Framework;

namespace JJTraveler.Tests
{
	/// <summary>
	/// Summary description for OneTest.
	/// </summary>
	public class OneTest : VisitorTestCase
	{
		public OneTest(string test) : base(test)
		{
		}
		public virtual void testOne() 
		{
			Identity id = new Identity();
			One     one = new One(logVisitor(id));
			Logger expected = new Logger(id, new IVisitable[]{n1});
			try 
			{
				IVisitable nodeReturned = one.visit(n0);
				Assertion.AssertEquals(expected, logger);
				Assertion.AssertEquals(n0, nodeReturned);
			} 
			catch (VisitFailure) 
			{
				Assertion.AssertEquals(expected, logger);
				//	    assertEquals(n0, nodeReturned);
				Assertion.Fail("VisitFailure should not occur!");
			}
		}

		public virtual void testOneLeaf() 
		{
			Identity id = new Identity();
			One     one = new One(logVisitor(id));
			Logger expected = new Logger();
			IVisitable nodeReturned = null;

			try 
			{
				nodeReturned = one.visit(n11);
				Assertion.Fail("One(leaf) should fail!");
			} 
			catch (VisitFailure) 
			{
				Assertion.AssertEquals(expected, logger);
				Assertion.AssertNull(nodeReturned);
			}
		}
	}
}
