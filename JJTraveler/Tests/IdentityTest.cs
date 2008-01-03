using System;
using dotUnit.Framework;

namespace JJTraveler.Tests
{
	/// <summary>
	/// Summary description for IdentityTest.
	/// </summary>

	public class IdentityTest : VisitorTestCase 
	{
		public IdentityTest(String test) : base(test)
		{
		}

		public virtual void testIdentity() // throws VisitFailure 
		{
			Identity id = new Identity();
			Logger expected = new Logger(id, n0);
			IVisitable nodeReturned = logVisitor(id).visit(n0);
			Assertion.AssertEquals(expected, logger);
			Assertion.AssertEquals(n0, nodeReturned);
		}
	}
}
