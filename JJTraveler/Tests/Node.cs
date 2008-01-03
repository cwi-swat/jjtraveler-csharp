using System;

namespace JJTraveler.Tests
{
	/// <summary>
	/// An implementation of the <code>Visitable</code> interface for
	/// testing purposes.
	/// </summary>
	public class Node : IVisitable
	{
		internal Node[] kids;
		internal int nodeID;

		internal static int nodeCounter = 0;

		public Node(Node[] kids, int nodeID) 
		{
			this.kids = kids;
			this.nodeID = nodeID;
		}

		public Node() 
		{
			this.kids = new Node[]{};
			this.nodeID = nodeCounter++;
		}

		public Node(Node[] kids) 
		{
			this.kids = kids;
			this.nodeID = nodeCounter++;
		}

		/**
		 * Create a new node with given kids. Each created node will have
		 * a different nodeID.
		 */
		public static Node factory(Node[] kids) 
		{
			Node result = new Node(kids, nodeCounter);
			nodeCounter++;
			return result;
		}

		public static void reset() 
		{
			nodeCounter = 0;
		}
	
		public virtual Node accept(NodeVisitor v) // throws jjtraveler.VisitFailure 
		{
            return v.visitNode(this);
        }

		public override String ToString() 
		{
			return "Node-" + nodeID;
		}

		#region IVisitable Members

		public virtual IVisitable getChildAt(int i)
		{
			return kids[i];
		}

		public virtual IVisitable setChildAt(int i, IVisitable child)
		{
			kids[i] = (Node) child;
			return this;
		}

		public virtual int getChildCount()
		{
			return kids.Length;
		}

		#endregion
	}
}
