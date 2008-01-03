using System;
using dotUnit.Framework;

namespace JJTraveler.Tests
{
	/// <summary>
	/// Test cases for Some, covering all failures, all successes,
	///  and leaf nodes.
	///
	/// @author Arie van Deursen, CWI
	/// @date December 2002.
	/// </summary>
	public class SomeTest : VisitorTestCase
	{
		public SomeTest(string test) : base(test)
		{
		}

		public virtual void testSomeIdentity() // VisitFailure 
		{
			Identity id = new Identity();
			Some     some = new Some(logVisitor(id));
			Logger expected = new Logger(id, new IVisitable[]{n1,n2});

			IVisitable nodeReturned = some.visit(n0);
			Assertion.AssertEquals(expected, logger);
			Assertion.AssertEquals(n0, nodeReturned);
	    }


		public virtual void testSomeAllFailures() 
		{
			Fail f = new Fail();
			Some     some = new Some(logVisitor(f));
			Logger expected = new Logger(f, new IVisitable[]{n1,n2});

			IVisitable nodeReturned = null;

			try {
				nodeReturned = some.visit(n0);
			} 
			catch (VisitFailure) 
			{
				Assertion.AssertEquals(expected, logger);
				Assertion.AssertNull(nodeReturned);
			}	
		}

		public virtual void testSomeOneFailure() // throws VisitFailure 
		{
			IVisitor v = new FailAtNodes(n1);
			Some     some = new Some(logVisitor(v));
			Logger expected = new Logger(v, new IVisitable[]{n1,n2});

			IVisitable nodeReturned = null;

			nodeReturned = some.visit(n0);
			Assertion.AssertEquals(expected, logger);
			Assertion.AssertEquals(n0, nodeReturned);
		}


		public virtual void testSomeLeaf() 
		{
			Identity id = new Identity();
			Some     some = new Some(logVisitor(id));
			Logger expected = new Logger();
			IVisitable nodeReturned = null;

			try
			{
				nodeReturned = some.visit(n11);
				Assertion.Fail("Some(leaf) should fail!");
			} 
			catch (VisitFailure)
			{
				Assertion.AssertEquals(expected, logger);
				Assertion.AssertNull(nodeReturned);
			}
		}
	}
}