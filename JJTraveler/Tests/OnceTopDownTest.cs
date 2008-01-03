using System;
using dotUnit.Framework;

namespace JJTraveler.Tests
{
	/// <summary>
	/// Summary description for OnceTopDownTest.
	/// </summary>
	public class OnceTopDownTest : VisitorTestCase
	{
		public OnceTopDownTest(string test) : base(test)
		{
		}
		public virtual void testOnceTopDownIsLeaf() 
		{
			IVisitor isLeaf = new All(new Fail());
			OnceTopDown onceTopDown = new OnceTopDown(logVisitor(isLeaf));
			Logger expected = new Logger(isLeaf, new IVisitable[]{n0,n1,n11});
			try 
			{
				IVisitable nodeReturned = onceTopDown.visit(n0);
				Assertion.AssertEquals("visit trace",expected, logger);
				Assertion.AssertEquals("return value",n0, nodeReturned);
			} 
			catch (VisitFailure) 
			{
				Assertion.Fail("VisitFailure should not occur!");
			}
		}

		public virtual void testOnceTopDownFail() 
		{
			IVisitor f = new Fail();
			OnceTopDown onceTopDown = new OnceTopDown(logVisitor(f));
			Logger expected = new Logger(f, new IVisitable[]{n0,n1,n11,n12,n2});
			IVisitable nodeReturned = null;
			try 
			{
				nodeReturned = onceTopDown.visit(n0);
				Assertion.Fail("VisitFailure should have occured!");
			} 
			catch (VisitFailure) 
			{
				Assertion.AssertEquals("visit trace",expected, logger);
				Assertion.AssertNull("return value",nodeReturned);
			}
		}
	}
}