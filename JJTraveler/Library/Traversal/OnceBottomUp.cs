using System;

namespace JJTraveler
{
	/// <summary>
	/// <code>OnceBottomUp(v) = Choice(One(OnceBottomUp(v)),v)</code>
	/// <p>
	/// Visitor combinator with one visitor argument that applies this
	/// visitor exactly once to the current visitable or one of its
	/// descendants, following the bottomup (post-order) traversal
	/// strategy.
	/// </summary>
	public class OnceBottomUp : Choice
	{
		/*
		 * Since it is not allowed to reference `this' before the
		 * super type constructor has been called, we can not
		 * write `super(One(this),v)'
		 * Instead, we set the first argument first to `null', and
		 * set it to its proper value afterwards.
		 */
		public OnceBottomUp(IVisitor v) : base(null,v)
		{
			first = new One(this);
		}
	}
}