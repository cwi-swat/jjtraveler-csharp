using System;
using dotUnit.Framework;

namespace JJTraveler.Tests
{
	/// <summary>
	/// Summary description for NestingDepthTest.
	/// </summary>
	public class NestingDepthTest : VisitorTestCase
	{
		public NestingDepthTest(string test) : base(test)
		{
		}
		public virtual void testDepth2() // throws VisitFailure 
		{
			IVisitor recognize = new SucceedAtNodes(n1, n12);
			NestingDepth nd = new NestingDepth(recognize);
			nd.visit(n0);
			Assertion.AssertEquals(2,nd.getDepth());
		}
		public virtual void testDepth1() // throws VisitFailure 
		{
			IVisitor recognize = new SucceedAtNodes(n1);
			NestingDepth nd = new NestingDepth(recognize);
			nd.visit(n0);
			Assertion.AssertEquals(1,nd.getDepth());
		}
		public virtual void testDepth11() // throws VisitFailure 
		{
			IVisitor recognize = new SucceedAtNodes(n1, n2);
			NestingDepth nd = new NestingDepth(recognize);
			nd.visit(n0);
			Assertion.AssertEquals(1,nd.getDepth());
		}

		public virtual void testNestingStopAt() // throws VisitFailure 
		{
			IVisitor recognize = new FailAtNodes(n1, n12);
			IVisitor goOnWhile = new SucceedAtNodes(n0, n1);
			NestingDepth nd = new NestingDepth(recognize, goOnWhile);
			nd.visit(n0);
			Assertion.AssertEquals(1, nd.getDepth());
		}
	}
}