using System;
using dotUnit.Framework;

namespace JJTraveler.Tests
{
	/// <summary>
	/// Various test cases for the rather tricky spine bottom up.
	///
	/// @author Arie van Deursen, CWI
	/// @date December 2002
	/// </summary>
	public class SpineBottomUpTest : VisitorTestCase
	{
		public SpineBottomUpTest(string test) : base(test)
		{
		}
		public virtual void testSpineBottomUpAtInnerNode() // throws VisitFailure \
		{
            IVisitor stop = new FailAtNodes(n1);
            SpineBottomUp spineBottomUp = new SpineBottomUp(logVisitor(stop));

            // after having tried n11, n1 fails.
            // searching then continues in n2 and goes up to n0.
            Logger expected = new Logger(stop, new IVisitable[]{n11,n1,n2,n0});

            IVisitable nodeReturned = spineBottomUp.visit(n0);

			Assertion.AssertEquals("visit trace",expected, logger);
			Assertion.AssertEquals("return value",n0, nodeReturned);
		}

	    public virtual void testSpineBottomUpAtLeaf() // throws VisitFailure 
		{
            IVisitor stop = new FailAtNodes(n11);
            SpineBottomUp spineBottomUp = new SpineBottomUp(logVisitor(stop));

            // n11 fails, so path to n12 is first to succeed,
            // and visited bottom up.
            Logger expected = new Logger(stop, new IVisitable[]{n11,n12,n1,n0});
            
            IVisitable nodeReturned = spineBottomUp.visit(n0);
            
			Assertion.AssertEquals("visit trace",expected, logger);
            Assertion.AssertEquals("return value",n0, nodeReturned);
	    }

		public virtual void testSpineBottomUpOnlySuccess() // throws VisitFailure \
		{
			IVisitor dontStop = new Identity();
            SpineBottomUp spineBottomUp = new SpineBottomUp(logVisitor(dontStop));

            // First path from n0 to n11 successful -- spinetopdown
            // won't search any further after that.
            Logger expected = new Logger(dontStop, new IVisitable[]{n11,n1,n0});

            IVisitable nodeReturned = spineBottomUp.visit(n0);

            Assertion.AssertEquals("visit trace",expected, logger);
			Assertion.AssertEquals("return value",n0, nodeReturned);
		}

		public virtual void testSpineBottomUpFailAtTop() 
		{
            IVisitor stop = new FailAtNodes(n0);
            SpineBottomUp spineBottomUp = new SpineBottomUp(logVisitor(stop));
            Logger expected = new Logger(stop, new IVisitable[]{n11,n1,n0});
            
			IVisitable nodeReturned = null;
            try 
			{
				nodeReturned = spineBottomUp.visit(n0);
				Assertion.Fail("VisitFailure should have occured!");
            } 
			catch (VisitFailure) 
			{
				Assertion.AssertEquals("visit trace",expected, logger);
				Assertion.AssertNull("return value",nodeReturned);
            }
		}

	    public virtual void testSpineBottomUpFailAtInners() 
		{
			IVisitor stop = new FailAtNodes(n1,n2);
            SpineBottomUp spineBottomUp = new SpineBottomUp(logVisitor(stop));
            Logger expected = new Logger(stop, new IVisitable[]{n11,n1,n2});
			IVisitable nodeReturned = null;
            try 
			{
                nodeReturned = spineBottomUp.visit(n0);
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
