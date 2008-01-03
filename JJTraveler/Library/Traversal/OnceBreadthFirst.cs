using System;
using System.Collections;

namespace JJTraveler
{
	/// <summary>
	/// <code>BF(v) = Seq(Try(Seq(v,All(EnQ))),IfThen(DeQ,BF(v)))</code>
	/// <p>
	/// Visit a tree in breadth-first order. The traversal is cut off below
	/// nodes where the argument visitor fails. Guaranteed to succeed.
	/// </summary>
	public class OnceBreadthFirst : IVisitor
	{
		internal Queue pending;
		internal IVisitor v;

		public OnceBreadthFirst(IVisitor v)
		{
			pending = new Queue();
			this.v = v;
		}
		public OnceBreadthFirst(IVisitor v, ICollection c) 
		{
			pending = new Queue(c);
			this.v = v;
		}
		#region IVisitor Members

		public virtual IVisitable visit(IVisitable x) // throws VisitFailure
		{
			try 
			{
				return v.visit(x);
			} 
			catch (VisitFailure) {}
			int childCount = x.getChildCount();
			for (int i = 0; i < childCount; i++) 
			{
				pending.Enqueue(x.getChildAt(i));
			}
			if (pending.Count != 0) 
			{
				IVisitable next = (IVisitable) pending.Dequeue();
				next = this.visit(next);
			}
			return x;
		}
		#endregion
	}
}