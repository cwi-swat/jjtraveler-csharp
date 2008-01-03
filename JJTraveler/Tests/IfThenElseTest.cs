using System;
using dotUnit.Framework;

namespace JJTraveler.Tests
{
	/// <summary>
	/// Summary description for IfThenElseTest.
	/// </summary>
	public class IfThenElseTest : VisitorTestCase
	{
		internal Identity idTrue = new Identity();
		internal Identity idFalse = new Identity();
		internal IVisitable nodeReturned;

		public IfThenElseTest(string test) : base(test)
		{
		}
		public virtual void testFalse() // throws VisitFailure 
		{
            Logger expected = new Logger();
			expected.log( new Event( idFalse, n0 ) );
	
			IVisitable nodeReturned = new IfThenElse( new Fail(), logVisitor(idTrue),logVisitor(idFalse)). visit(n0);

			Assertion.AssertEquals(expected, logger);
			Assertion.AssertEquals("input node is returned", n0, nodeReturned);
		}

		public virtual void testTrue() // throws VisitFailure 
		{
			Logger expected = new Logger();
			expected.log( new Event( idTrue, n0 ) );

			IVisitable nodeReturned = new IfThenElse( new Identity(), logVisitor(idTrue), logVisitor(idFalse)).visit(n0);

			Assertion.AssertEquals(expected, logger);
			Assertion.AssertEquals(n0, nodeReturned);
		}

		public virtual void testTrueFailingThen() // throws VisitFailure 
        {
            Fail failingThen = new Fail();
            Logger expected = new Logger();
            expected.log( new Event( failingThen, n0 ) );

			try 
			{
				nodeReturned = new IfThenElse( new Identity(), logVisitor(failingThen),	logVisitor(idFalse)).visit(n0);
				Assertion.Fail();
			} 
			catch(VisitFailure) 
			{
				Assertion.AssertEquals("trace", expected, logger);
				Assertion.AssertNull("returned node", nodeReturned);
			}
        }
    }
}

