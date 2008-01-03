using System;
using System.Collections;

namespace JJTraveler
{
	/// <summary>
	/// <code>BF(v) = Seq(v,All(EnQ),IfThen(DeQ,BF(v)))</code>
	/// <p>
	/// Visit a tree in breadth-first order. Fails iff the argument visitor fails
	/// on any of the nodes of the tree.
	/// </summary>
	public class BreadthFirst : IVisitor
	{
		internal Queue pending;
		internal IVisitor v;
		public BreadthFirst(IVisitor v)
		{
			pending = new Queue();
			this.v = v;
		}
		public BreadthFirst(IVisitor v, ICollection c) 
		{
			pending = new Queue(c);
			this.v = v;
		}
		#region IVisitor Members

		public virtual IVisitable visit(IVisitable x) // throws VisitFailure
		{
			IVisitable result = v.visit(x);
			int childCount = result.getChildCount();

			for (int i = 0; i < childCount; i++) 
			{
				pending.Enqueue(result.getChildAt(i));
			}

			if (pending.Count != 0) 
			{
				IVisitable next = (IVisitable) pending.Dequeue();
				next = this.visit(next);
			}

			return result;
		}

		#endregion
	}
}

