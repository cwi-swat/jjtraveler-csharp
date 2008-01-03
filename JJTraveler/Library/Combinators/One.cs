using System;

namespace JJTraveler
{
	/// <summary>
	/// <code>T(t1,..,ti,..,tN).accept(One(v)) = T(t1,...ti.accept(v),..,tN)</code>
	/// if <code>ti</code> is the first child that succeeds.
	/// <p>
	/// Basic visitor combinator with one visitor argument, that applies
	/// this visitor to exactly one child. If no children are visited 
	/// successfully, then One(v) fails.
	/// <p>
	/// Note that side-effects of failing visits to children are not
	/// undone.
	/// </summary>
	public class One : IVisitor
	{
		public IVisitor v;

		public One(IVisitor v)
		{
			this.v = v;
		}
		#region IVisitor Members

		public virtual IVisitable visit(IVisitable any) // throws VisitFailure
		{
			int childCount = any.getChildCount();
			for (int i = 0; i < childCount; i++) 
			{
				try 
				{ 
					return any.setChildAt(i,v.visit(any.getChildAt(i))); 
				} 
				catch(VisitFailure) {}
			}
			throw new VisitFailure();
		}
		}

		#endregion
	}