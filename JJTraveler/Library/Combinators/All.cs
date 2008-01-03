using System;

namespace JJTraveler
{
	/// <summary>
	/// All(v).visit(T(t1,...,tN) = T(v.visit(t1), ..., v.visit(t1))</code>
	/// <p>
	/// Basic visitor combinator with one visitor argument, that applies
	/// this visitor to all children.
	/// </summary>
	public class All : IVisitor
	{
		public IVisitor v;
		public All(IVisitor v)
		{
            this.v = v;
		}
		#region IVisitor Members

		public virtual IVisitable visit(IVisitable any) // throws VisitFailure
		{
			int childCount = any.getChildCount();
			IVisitable result = any;
			for (int i = 0; i < childCount; i++) 
			{
				result.setChildAt(i, v.visit(result.getChildAt(i)));
			}
			return result;
		}

		#endregion

		// Factory method
		public virtual All make(IVisitor v) 
		{
			return new All(v);
		}
		internal virtual void setArgumentTo(IVisitor v) 
		{
			this.v = v;
		}
	}
}
