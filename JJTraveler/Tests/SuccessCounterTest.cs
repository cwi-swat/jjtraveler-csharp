using System;
using dotUnit.Framework;

namespace JJTraveler.Tests
{
	/// <summary>
	/// Test cases for the SuccessCounter
	/// combinator.
	/// 
	/// @author Arie van Deursen; Jun 30, 2003 
	/// @version $Id: SuccessCounterTest.java,v 1.3.2.1 2004/04/14 12:51:41 jurgenv Exp $
	/// </summary>
	public class SuccessCounterTest : VisitorTestCase
	{
		public SuccessCounterTest(string test) : base(test)
		{
		}
		public virtual void testSuccessCounter() // throws VisitFailure 
        {
            IVisitor action = new FailAtNodes(n1, n2);
            SuccessCounter sc = new SuccessCounter(action);

            IVisitable nodeReturned = (new TopDown(sc)).visit(n0);

			Assertion.AssertEquals(n0, nodeReturned);
			Assertion.AssertEquals(3, sc.getSuccesses());
			Assertion.AssertEquals(2, sc.getFailures());
        }
    }
}

