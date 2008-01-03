using System;
using dotUnit.Framework;

namespace JJTraveler.Tests
{
	/// <summary>
	/// Test cases for TopDownUntil,
	///  illustrating its effect with a 
	///  failing condition. 
	/// 
	/// @author Arie van Deursen; Jun 30, 2003 
	/// @version $Id: TopDownUntilTest.java,v 1.5.2.1 2004/04/14 12:51:41 jurgenv Exp $
	/// </summary>
	public class TopDownUntilTest : VisitorTestCase
	{
		internal IVisitor stopAt;
		internal Logger expected;
		public TopDownUntilTest(string test) : base(test)
		{
		}
		protected override void SetUp() 
		{
			base.SetUp();
			stopAt = new SucceedAtNodes(n1, n2);
			expected = new Logger();
		}

		public virtual void testTopDownUntil() // throws VisitFailure 
		{
			expected.log(new Event(stopAt, n0));
			expected.log(new Event(stopAt, n1));
			expected.log(new Event(stopAt, n2));

			IVisitable nodeReturned = 
				new TopDownUntil(logVisitor(stopAt)).visit(n0);

			Assertion.AssertEquals(expected, logger);
			Assertion.AssertEquals(n0, nodeReturned);
		}
	
		public virtual void testTopDownAtBorder() // throws VisitFailure 
		{
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