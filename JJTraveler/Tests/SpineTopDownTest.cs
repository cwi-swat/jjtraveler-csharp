using System;
using dotUnit.Framework;

namespace JJTraveler.Tests
{
	/// <summary>
	/// Various test cases for the rather tricky spine top down.
	///
	/// @author Arie van Deursen, CWI
	/// @date December 2002
	/// </summary>
	public class SpineTopDownTest : VisitorTestCase
	{
		public SpineTopDownTest(string test) : base(test)
		{
		}
	    public virtual void testSpineTopDownAtInnerNode() // throws VisitFailure 
		{
            IVisitor stop = new FailAtNodes(n1);
            SpineTopDown spineTopDown = new SpineTopDown(logVisitor(stop));

            // n1 fails, so searching continues in n2.
            Logger expected = new Logger(stop, new IVisitable[]{n0,n1,n2});

            IVisitable nodeReturned = spineTopDown.visit(n0);

            Assertion.AssertEquals("visit trace",expected, logger);
			Assertion.AssertEquals("return value",n0, nodeReturned);
		}

	    public virtual void testSpineTopDownAtLeaf() // throws VisitFailure 
		{
			IVisitor stop = new FailAtNodes(n11);
            SpineTopDown spineTopDown = new SpineTopDown(logVisitor(stop));

            // n11 fails, so path to n12 is first to succeed.
            Logger expected = new Logger(stop, new IVisitable[]{n0,n1,n11,n12});

            IVisitable nodeReturned = spineTopDown.visit(n0);

            Assertion.AssertEquals("visit trace",expected, logger);
            Assertion.AssertEquals("return value",n0, nodeReturned);
        }

	    public virtual void testSpineTopDownOnlySuccess() // throws VisitFailure 
		{
			IVisitor dontStop = new Identity();
            SpineTopDown spineTopDown = new SpineTopDown(logVisitor(dontStop));

            // First path from n0 to n11 successful -- spinetopdown
            // won't search any further after that.
            Logger expected = new Logger(dontStop, new IVisitable[]{n0,n1,n11});

            IVisitable nodeReturned = spineTopDown.visit(n0);

            Assertion.AssertEquals("visit trace",expected, logger);
			Assertion.AssertEquals("return value",n0, nodeReturned);
        }

		public virtual void testSpineTopDownFailAtTop() 
		{
			IVisitor stop = new FailAtNodes(n0);
            SpineTopDown spineTopDown = new SpineTopDown(logVisitor(stop));
            Logger expected = new Logger(stop, new IVisitable[]{n0});
			IVisitable nodeReturned = null;
            try 
			{
                nodeReturned = spineTopDown.visit(n0);
				Assertion.Fail("VisitFailure should have occured!");
            } 
			catch (VisitFailure) 
			{
				Assertion.AssertEquals("visit trace",expected, logger);
				Assertion.AssertNull("return value",nodeReturned);
            }
        }
	    public virtual void testSpineTopDownFailAtInners() 
		{
			IVisitor stop = new FailAtNodes(n1,n2);
            SpineTopDown spineTopDown = new SpineTopDown(logVisitor(stop));
            Logger expected = new Logger(stop, new IVisitable[]{n0,n1,n2});
			IVisitable nodeReturned = null;
            try 
			{
                nodeReturned = spineTopDown.visit(n0);
				Assertion.Fail("VisitFailure should have occured!");
            } 
			catch (VisitFailure)
			{
				Assertion.AssertEquals("visit trace",expected, logger);
				Assertion.AssertNull("return value",nodeReturned);
            }
        }
	}
}
