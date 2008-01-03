using System;
using dotUnit.Framework;

namespace JJTraveler.Tests
{
	/// <summary>
	/// Various test cases for the rather tricky all spines bottom up.
	///
	/// @author Arie van Deursen, CWI
	/// @date December 2002
	/// </summary>
	public class AllSpinesBottomUpTest : VisitorTestCase
	{
		public AllSpinesBottomUpTest(string test) : base(test)
		{
		}
		public virtual void testn1Success() // throws VisitFailure 
		{
			IVisitor action = new Identity();
			IVisitor goDown = new Identity();
			IVisitor successNode = new SucceedAtNodes(n1);
			AllSpinesBottomUp asbu =
				new AllSpinesBottomUp(goDown, successNode, logVisitor(action));

			Logger expected = new Logger(action, new IVisitable[]{n1,n0});

			IVisitable nodeReturned = asbu.visit(n0);

			Assertion.AssertEquals("visit trace",expected, logger);
			Assertion.AssertEquals("return value",n0, nodeReturned);
		}

		public virtual void testn2Success() // throws VisitFailure 
		{
			IVisitor action = new Identity();
			IVisitor goDown = new Identity();
			IVisitor successNode = new SucceedAtNodes(n2);
			AllSpinesBottomUp asbu =
				new AllSpinesBottomUp(goDown, successNode, logVisitor(action));

			Logger expected = new Logger(action, new IVisitable[]{n2,n0});

			IVisitable nodeReturned = asbu.visit(n0);

			Assertion.AssertEquals("visit trace",expected, logger);
			Assertion.AssertEquals("return value",n0, nodeReturned);
		}

		public virtual void testFailAtn1() // throws VisitFailure 
		{
			IVisitor action = new Identity();
			IVisitor goDown = new FailAtNodes(n1);
			IVisitor successNode = new SucceedAtNodes(n12,n2);
			AllSpinesBottomUp asbu =
				new AllSpinesBottomUp(goDown, successNode, logVisitor(action));

			Logger expected = new Logger(action, new IVisitable[]{n2,n0});

			IVisitable nodeReturned = asbu.visit(n0);

			Assertion.AssertEquals("visit trace",expected, logger);
			Assertion.AssertEquals("return value",n0, nodeReturned);
		}

		public virtual void testMultiplePaths() // throws VisitFailure 
		{
			IVisitor action = new Identity();
			IVisitor goDown = new Identity();
			IVisitor successNode = new SucceedAtNodes(n12,n2);
			AllSpinesBottomUp asbu =
				new AllSpinesBottomUp(goDown, successNode, logVisitor(action));

			Logger expected = new Logger(action, new IVisitable[]{n12,n1,n2,n0});

			IVisitable nodeReturned = asbu.visit(n0);

			Assertion.AssertEquals("visit trace",expected, logger);
			Assertion.AssertEquals("return value",n0, nodeReturned);
		}
	}
}