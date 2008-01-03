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
	public class BreadthFirstWhile : IVisitor
	{
		internal Queue pending;
		internal IVisitor v;
		public BreadthFirstWhile(IVisitor v)
		{
			pending = new Queue();
			this.v = v;
		}
		public BreadthFirstWhile(IVisitor v, ICollection c) 
		{
			pending = new Queue(c);
			this.v = v;
		}
		#region IVisitor Members

		public virtual IVisitable visit(IVisitable x)
		{
			IVisitable result = x;
			try 
			{
				result = v.visit(x);
				int childCount = result.getChildCount();
				for (int i = 0; i < childCount; i++) 
				{
					pending.Enqueue(result.getChildAt(i));
				}
			} 
			catch (VisitFailure) {}
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