using System;
using System.Collections;
using dotUnit.Framework;

namespace JJTraveler.Tests
{
	/// <summary>
	/// Summary description for CollectTest.
	/// </summary>
	public class CollectTest : VisitorTestCase
	{
		public CollectTest(string test) : base(test)
		{
		}
		public virtual void testCollectTopDown() 
		{
			ArrayList c = new ArrayList();
			(Collect.topdown(new Identity(),c)).visit(n0);
			ArrayList expected = new ArrayList();
			expected.Add(n0);
			expected.Add(n1);
			expected.Add(n11);
			expected.Add(n12);
			expected.Add(n2);

			// Testing without Collection data type
			foreach(Object o in expected) 
			{
				Assertion.AssertTrue(c.Contains(o));
			}
			Assertion.AssertEquals(expected.Count, c.Count);
//			Assertion.AssertEquals(expected,c);
		}

		public virtual void testCollectAll() 
		{
			ArrayList c = new ArrayList();
			(Collect.all(new Identity(),c)).visit(n0);
			ArrayList expected = new ArrayList();
			expected.Add(n1);
			expected.Add(n2);
			// Testing without Collection data type
			foreach(Object o in expected) 
			{
				Assertion.AssertTrue(c.Contains(o));
			}
			Assertion.AssertEquals(expected.Count, c.Count);
//			Assertion.AssertEquals(expected,c);
		}
	}
}