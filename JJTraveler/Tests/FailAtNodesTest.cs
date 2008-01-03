using System;
using System.Collections;
using dotUnit.Framework;

namespace JJTraveler.Tests
{
	/// <summary>
	/// Summary description for FailAtNodesTest.
	/// </summary>
	public class FailAtNodesTest : VisitorTestCase
	{
		public FailAtNodesTest(string test) : base(test)
		{
		}
		public virtual void testFailAtSomeNode() // throws VisitFailure 
        {
            IVisitor v = new FailAtNodes(n0,n1);
			try
			{
				(logVisitor(v)).visit(n0);
				Assertion.Fail("VisitFailure should have occured");
			} 
			catch (VisitFailure)
			{
				Logger expected = new Logger();
				expected.log(new Event(v,n0));
				Assertion.AssertEquals(expected,logger);
			}
        }
        public virtual void testSucceedAtSomeNode() // throws VisitFailure 
		{
            IVisitor v = new FailAtNodes(n1,n2);
            (logVisitor(v)).visit(n0);
            Logger expected = new Logger();
			expected.log(new Event(v,n0));
			Assertion.AssertEquals(expected,logger);
        }
        public virtual void testFailAtSomeNodes() // throws VisitFailure 
        {
            ArrayList nodes = new ArrayList();
            nodes.Add(n0);
			nodes.Add(n1);
			nodes.Add(n11);
            IVisitor v = new FailAtNodes(nodes);
            new Not((logVisitor(v))).visit(n0);
			new Not((logVisitor(v))).visit(n1);
			(logVisitor(v)).visit(n2);
            new Not((logVisitor(v))).visit(n11);
			(logVisitor(v)).visit(n12);
			Logger expected = new Logger();
			expected.log(new Event(v,n0));
			expected.log(new Event(v,n1));
			expected.log(new Event(v,n2));
			expected.log(new Event(v,n11));
			expected.log(new Event(v,n12));
			Assertion.AssertEquals(expected,logger);
        }
	}
}
