using System;
using dotUnit.Framework;

namespace JJTraveler.Tests
{
	/// <summary>
	/// Various test cases for
	/// the various selected forms of the
	/// DoWhileSuccess combinator. 
	/// 
	/// @author Arie van Deursen; Jun 30, 2003 
	/// @version $Id: DoWhileSuccessTest.java,v 1.6.2.1 2004/04/14 12:51:40 jurgenv Exp $
	/// </summary>
	public class DoWhileSuccessTest : VisitorTestCase
	{
		public DoWhileSuccessTest(string test) : base(test)
		{
		}
		public virtual void testDoWhileSuccess() // throws VisitFailure 
		{
			IVisitor condition = new FailAtNodes(n1, n2);
			IVisitor action = new Identity();

			Logger expected = new Logger();
			expected.log(new Event(condition, n0));
			expected.log(new Event(action, n0));
			expected.log(new Event(condition, n1));
			expected.log(new Event(condition, n2));

			IVisitable nodeReturned =
				new DoWhileSuccess(
				logVisitor(condition),
				logVisitor(action)).visit(
				n0);

			Assertion.AssertEquals(expected, logger);
			Assertion.AssertEquals(n0, nodeReturned);
		}

		public virtual void testTopDownUntil() // throws VisitFailure 
		{
			IVisitor stopAt = new SucceedAtNodes(n1, n2);

			Logger expected = new Logger();
			expected.log(new Event(stopAt, n0));
			expected.log(new Event(stopAt, n1));
			expected.log(new Event(stopAt, n2));

			IVisitable nodeReturned =
				DoWhileSuccess.TopDownUntil(logVisitor(stopAt)).visit(n0);

			Assertion.AssertEquals(expected, logger);
			Assertion.AssertEquals(n0, nodeReturned);
		}

		public virtual void testTopDownUntilAtBorder() // throws VisitFailure 
		{
			IVisitor stopAt = new SucceedAtNodes(n1, n2);

			Logger expected = new Logger();

			IVisitor borderAction = new Identity();
		
			expected.log(new Event(stopAt, n0));
			expected.log(new Event(stopAt, n1));
			expected.log(new Event(borderAction, n1));
			expected.log(new Event(stopAt, n2));
			expected.log(new Event(borderAction, n2));

			IVisitable nodeReturned = 
				new TopDownUntil(logVisitor(stopAt),
				logVisitor(borderAction)
				).visit(n0);

			Assertion.AssertEquals(expected, logger);
			Assertion.AssertEquals(n0, nodeReturned);
		}
	}
}
