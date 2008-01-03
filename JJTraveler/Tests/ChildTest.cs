using System;
using dotUnit.Framework;

namespace JJTraveler.Tests
{
	/// <summary>
	/// Test the Child combinator, distinguishing
	/// condition failure and success.
	/// 
	/// @author Arie van Deursen; Jul 8, 2003 
	/// @version $Id: ChildTest.java,v 1.1.2.2 2004/04/14 13:11:21 jurgenv Exp $  
	/// </summary>
	public class ChildTest : VisitorTestCase
	{
		internal IVisitor childVisitor;
		internal IVisitor childAction;
		internal IVisitor condition;
		internal Logger expected;

		public ChildTest(string name) : base(name)
		{
		}
		protected override void SetUp() 
		{
			base.SetUp();
			childAction = new Identity();
			expected = new Logger();
		}



		public virtual void testConditionFails() // throws VisitFailure 
		{
			condition = new FailAtNodes(n0);
			expected.log(new Event(condition, n0));
			childVisitor = 
				new Child(logVisitor(condition), logVisitor(childAction));
			IVisitable nodeReturned = childVisitor.visit(n0);
			Assertion.AssertEquals(expected, logger);
			Assertion.AssertEquals(nodeReturned, n0);
		}
	
	
		public virtual void testConditionSucceeds() // throws VisitFailure 
		{
			condition = new SucceedAtNodes(n0);
			expected.log(new Event(condition, n0));
			expected.log(new Event(childAction, n1));
			expected.log(new Event(childAction, n2));
			childVisitor = 
				new Child(logVisitor(condition), logVisitor(childAction));
			IVisitable nodeReturned = childVisitor.visit(n0);
			Assertion.AssertEquals(expected, logger);
			Assertion.AssertEquals(nodeReturned, n0);		
		}
	}
}