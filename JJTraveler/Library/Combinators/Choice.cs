using System;

namespace JJTraveler
{
	/// <summary>
	/// <code>Choice(v1,v2) = v1</code>    if v1 succeeds
	/// <p>
	/// <code>Choice(v1,v2) = v2</code>    if v1 fails
	/// <p>
	/// Visitor combinator with two visitor arguments, that tries to
	/// apply the first visitor and if it fails tries the other 
	/// (left-biased choice).
	/// <p>
	/// Note that any side-effects of v1 are not undone when it fails.
	/// </summary>
	public class Choice : IVisitor
	{
		internal IVisitor first;
		internal IVisitor then;

		public Choice(IVisitor first, IVisitor then) 
		{
			this.first = first;
			this.then  = then;
		}

		#region IVisitor Members

		public virtual IVisitable visit(IVisitable visitable)
		{
			try 
			{
				return first.visit(visitable);
			}
			catch (VisitFailure) 
			{
				return then.visit(visitable);
			}
		}
		#endregion

		// should be done with standard setters (attributes)
		internal virtual void setFirst(IVisitor first) 
		{
			this.first = first;
		}
		// should be done with standard setters (attributes)
		internal virtual void setThen(IVisitor then) 
		{
			this.then  = then;
		}
	}
}
