using System;
using dotUnit.Framework;

namespace JJTraveler.Tests
{
	/// <summary>
	/// Testing the Descendant(condition, action)
	/// considers condition failure, and condition success
	/// at different nesting depths.
	/// 
	/// @author Arie van Deursen; Jul 8, 2003 
	/// @version $Id: DescendantTest.java,v 1.1.2.1 2004/04/14 12:51:40 jurgenv Exp $  
	/// </summary>
	public class DescendantTest : VisitorTestCase
	{
		internal IVisitor childVisitor;
		internal IVisitor childAction;
		internal IVisitor condition;
		internal Logger expected;

		public DescendantTest(string test) : base(test)
		{
		}
		protected override void SetUp()
		{
			base.SetUp();
			childAction = new Identity();
			expected = new Logger();
		}
		public virtual void testConditionFailsAtTop() // throws VisitFailure 
		{
			condition = new FailAtNodes(n0);
			expected.log(new Event(condition, n0));
			expected.log(new Event(condition, n1));
			expected.log(new Event(childAction, n11));
			expected.log(new Event(childAction, n12));
			expected.log(new Event(condition, n2));		
			childVisitor = 
				new Descendant(logVisitor(condition), logVisitor(childAction));
			IVisitable nodeReturned = childVisitor.visit(n0);
			Assertion.AssertEquals(expected, logger);
			Assertion.AssertEquals(nodeReturned, n0);
		}
	
		public virtual void testConditionSucceedsAtTop() // throws VisitFailure 
		{
			condition = new SucceedAtNodes(n0);
			expected.log(new Event(condition, n0));
			expected.log(new Event(childAction, n1));
			expected.log(new Event(childAction, n2));
			childVisitor = 
				new Descendant(logVisitor(condition), logVisitor(childAction));
			IVisitable nodeReturned = childVisitor.visit(n0);
			Assertion.AssertEquals(expected, logger);
			Assertion.AssertEquals(nodeReturned, n0);		
		}
	}
}
