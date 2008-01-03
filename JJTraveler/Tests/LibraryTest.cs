using System;
using System.Collections;
using dotUnit.Framework;

namespace JJTraveler.Tests
{
	/// <summary>
	/// Summary description for LibraryTest.
	/// </summary>
	public class LibraryTest : TestCase
	{
		internal Node n0;    //          4
		internal Node n1;    //         / \
		internal Node n2;    //        3   2
		internal Node n3;    //       / \
		internal Node n4;    //      0   1

		internal Logger logger;

		public LibraryTest(string test) : base(test)
		{
		}
		protected override void SetUp() 
		{
			Node.reset();
			Node[] empty = {};
			logger = new Logger();
			n0 = Node.factory(empty);
			n1 = Node.factory(empty);
			n2 = Node.factory(empty);
			n3 = Node.factory(new Node[]{n0,n1});
			n4 = Node.factory(new Node[]{n3,n2});
		}

		public virtual void testSequence() // throws VisitFailure 
		{
			Identity id1 = new Identity();
			Identity id2 = new Identity();

			Logger expected = new Logger();
			expected.log( new Event(id1, n0) );
			expected.log( new Event(id2, n0) );

			Sequence  ls = new Sequence( logVisitor(id1), logVisitor(id2) );

			IVisitable nodeReturned = ls.visit(n0);

			Assertion.AssertEquals(expected, logger);
			Assertion.AssertEquals(nodeReturned, n0);
		}

		public virtual void testLeftChoice() // throws VisitFailure 
		{
			Identity id = new Identity();
			Logger expected = new Logger(id, new IVisitable[]{n0} );

			Choice  ch = new Choice( logVisitor(id), new Identity() );

			IVisitable nodeReturned = ch.visit(n0);
			Assertion.AssertEquals(expected, logger);
			Assertion.AssertEquals(n0, nodeReturned);
		}


		public virtual void testRightChoice() // throws VisitFailure 
		{
			Identity id = new Identity();
			Logger expected = new Logger(id, new IVisitable[]{n0} );

			Choice  ch = new Choice( new Fail(), logVisitor(id) );

			IVisitable nodeReturned = ch.visit(n0);
			Assertion.AssertEquals(expected, logger);
			Assertion.AssertEquals(n0, nodeReturned);
		}


		public virtual void testAll() // throws jjtraveler.VisitFailure 
		{
			Identity id = new Identity();
			Logger expected = new Logger(id, new IVisitable[]{n3, n2} );

			All  all = new All( logVisitor(id) );

			IVisitable nodeReturned = all.visit(n4);
			Assertion.AssertEquals(expected, logger);
			Assertion.AssertEquals(n4, nodeReturned);
		}

		public virtual void testBottomUp() // throws jjtraveler.VisitFailure 
		{
			Identity id = new Identity();
			Logger expected = new Logger(id, new IVisitable[]{n0, n1, n3, n2, n4} );

			BottomUp  visitor = new BottomUp( logVisitor(id) );

			IVisitable nodeReturned = visitor.visit(n4);
			Assertion.AssertEquals(expected, logger);
			Assertion.AssertEquals(n4, nodeReturned);
		}

		public virtual void testTopDown() // throws jjtraveler.VisitFailure 
		{
			Identity id = new Identity();
			Logger expected = new Logger(id, new IVisitable[]{n4, n3, n0, n1, n2} );

			IVisitor  visitor = new TopDown( logVisitor(id) );

			IVisitable nodeReturned = visitor.visit(n4);
			Assertion.AssertEquals(expected, logger);
			Assertion.AssertEquals(n4, nodeReturned);
		}

		public virtual void testDownUp() // throws jjtraveler.VisitFailure 
		{
			Identity id = new Identity();
			Logger expected = new Logger(id, 
				new IVisitable[]{n4, n3, n0, n0, n1, n1, n3, n2, n2, n4 } );

			IVisitor visitor = new DownUp( logVisitor(id), logVisitor(id) );

			IVisitable nodeReturned = visitor.visit(n4);
			Assertion.AssertEquals(expected, logger);
			Assertion.AssertEquals(n4, nodeReturned);
		}

		public virtual void testNonStopDownUp() // throws jjtraveler.VisitFailure 
		{
			Identity downId = new Identity();
			Identity upId = new Identity();
			Fail stop = new Fail();

			Logger expected = new Logger();
			expected.log( new Event(downId, n3) );
			expected.log( new Event(downId, n0) );
			expected.log( new Event(upId, n0) );
			expected.log( new Event(downId, n1) );
			expected.log( new Event(upId, n1) );
			expected.log( new Event(upId, n3) );

			IVisitor  visitor = new DownUp( 
				logVisitor(downId), stop, logVisitor(upId) );

			IVisitable nodeReturned = visitor.visit(n3);
			Assertion.AssertEquals(expected, logger);
			Assertion.AssertEquals(n3, nodeReturned);
		}

		public virtual void testStopDownUp() // throws jjtraveler.VisitFailure 
		{
			Identity downId = new Identity();
			Identity upId = new Identity();
			Identity stopId = new Identity();

			Logger expected = new Logger();
			expected.log( new Event(downId, n4) );
			expected.log( new Event(stopId, n4) );
			expected.log( new Event(upId, n4) );

			IVisitor  visitor = new DownUp( 
				logVisitor(downId), logVisitor(stopId), logVisitor(upId) );

			IVisitable nodeReturned = visitor.visit(n4);
			Assertion.AssertEquals(expected, logger);
			Assertion.AssertEquals(n4, nodeReturned);
		}
		internal class Def : Identity, ICollector 
		{
			public ICollection getCollection() 
			{
				ArrayList result = new ArrayList();
				result.Add("aap");
				result.Add("noot");
				return result;
			}
		}
		internal class Use : Identity , ICollector 
		{
			public ICollection getCollection() 
			{
				ArrayList result = new ArrayList();
				result.Add("aap");
				result.Add("mies");
				return result;
			}
		}
#if false
		public void testDefUse() // throws jjtraveler.VisitFailure 
		{
			Def def = new Def();
			Use use = new Use();
			DefUse du = new DefUse(use, def);
			du.visit(n0);
			Assertion.AssertTrue( du.getUnused().contains("noot"));
			Assertion.AssertTrue( du.getUndefined().contains("mies"));
			Assertion.AssertEquals(1, du.getUnused().size());
			Assertion.AssertEquals(1, du.getUndefined().size());
		}
#endif

		public class Increment : IStateVisitor 
		{
			public Object localState = null;
			public int state = 0;
			public virtual Object getState() {return state;}
			public virtual void setState(Object o) {state = ((Int32) o);}
			public virtual IVisitable visit(IVisitable x) 
			{
				state++; 
				localState = getState();
				return x;
			}
		}

		public virtual void testBacktrack() //     throws jjtraveler.VisitFailure 
		{
			Increment i = new Increment();
			Object initialState = i.getState();
			(new Backtrack(i)).visit(n0);
			Assertion.AssertNotNull(i.localState);
			Assertion.AssertTrue(! initialState.Equals(i.localState));
			Assertion.AssertEquals(initialState,i.getState());
		}	

		public virtual LogVisitor logVisitor(IVisitor v) 
		{
			return new LogVisitor(v, logger);
		}


		public virtual void testBreadthFirst() //     throws jjtraveler.VisitFailure 
		{
			Identity id = new Identity();
			Logger expected = new Logger(id, new IVisitable[]{n4, n3, n2, n0, n1} );

			BreadthFirst bf = new BreadthFirst( logVisitor(id) );

			IVisitable resultNode = bf.visit(n4);
			Assertion.AssertEquals(expected, logger);
			Assertion.AssertEquals(resultNode, n4);
		}

		public virtual void testNotOnFailure() //		throws jjtraveler.VisitFailure 
		{
			Not not = new Not(new Fail());
			IVisitable resultNode = not.visit(n0);
			Assertion.AssertEquals(n0,resultNode);
		}
		public virtual void testNotOnSuccess() //	throws jjtraveler.VisitFailure 
		{
			Not not = new Not(new Identity());
			IVisitable resultNode = null;
			try 
			{
				resultNode = not.visit(n0);
				Assertion.Fail("VisitFailure should have occured");
			} 
			catch (VisitFailure) 
			{
				Assertion.AssertNull(resultNode);
			}
		}
				 

	}
}
