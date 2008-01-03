using System;
using dotUnit.Framework;

namespace JJTraveler.Tests
{
	/// <summary>
	/// This extension of TestCase can be used to test generic visitor
	/// combinators.
	/// </summary>
	public abstract class VisitorTestCase : TestCase
	{
		/** 
		 * Nodes in a simple tree that can be used for
		 * testing traversals.
		 * Names correspond to paths in the tree:
		 * <pre>
		 *        n0
		 *      /    \
		 *    n1     n2
		 *    / \    
		 * n11  n12
		 * </pre>
		 */
		internal Node n0;
		internal Node n1;
		internal Node n11;
		internal Node n12;
		internal Node n2;

		public virtual Node buildTree() 
		{
			n11 = new Node(); // Node-0
			n12 = new Node(); // Node-1
			n1  = new Node(new Node[]{n11,n12}); // Node-2
			n2  = new Node(); // Node-3
			n0  = new Node(new Node[]{n1,n2}); // Node-4
			return n0;
		}

		internal Node rootOfDiamond;
		internal virtual void buildDiamond() 
		{
			Node sink = new Node();
			rootOfDiamond = new Node(new Node[]{sink,sink});
		}

		internal Node rootOfCircle;
		internal virtual void buildCircle() 
		{
			Node node = new Node(new Node[]{null});
			rootOfCircle = new Node(new Node[]{node});
			node.setChildAt(0,rootOfCircle);
		}

		public Logger logger;

		protected override void SetUp() 
		{
			Node.reset();
			buildTree();
			buildDiamond();
			buildCircle();
			logger = new Logger();
		}

		/** Many test cases will need a logging visitor:
		 * this methods returns one.
		 */
		public virtual LogVisitor logVisitor(IVisitor v) 
		{
			return new LogVisitor(v, logger);
		}

		public VisitorTestCase(String name) : base(name)
		{
		}
	}
}

