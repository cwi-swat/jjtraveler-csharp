using System;

namespace JJTraveler
{
	/// <summary>
	/// <code>T(t1,..,ti,..,tN).accept(Some(v)) = T(t1,...ti.accept(v),..,tN)</code>
	/// for each <code>ti</code> that succeeds.
	/// <p>
	/// Basic visitor combinator with one visitor argument, that applies
	/// this visitor to all children. If no children are visited 
	/// successfully, then Some(v) fails.
	/// <p>
	/// Note that side-effects of failing visits to children are not
	/// undone.
	///
	/// @author Arie van Deursen. Based on One.java
	/// @date December 2002.
	/// </summary>
	public class Some : IVisitor
	{
		public IVisitor v;
		public Some(IVisitor v)
		{
			this.v = v;
		}
		#region IVisitor Members

		public virtual IVisitable visit(IVisitable any) // throws VisitFailure
		{
			int childCount = any.getChildCount();
			int successCount = 0;
			for (int i = 0; i < childCount; i++) 
			{
				try 
				{ 
					any.setChildAt(i,v.visit(any.getChildAt(i))); 
					successCount++;
				} 
				catch(VisitFailure) {}
			}
			if (successCount == 0) 
			{
				throw new VisitFailure("Some: None of the " + 
					childCount + " arguments of " +
					any + " succeeded.");
			}
			return any;
		}
		#endregion
	}
}

