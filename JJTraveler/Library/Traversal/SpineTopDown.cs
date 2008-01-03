using System;

namespace JJTraveler
{
	/// <summary>
	/// <code>SpineTopDown(v) = Sequence(v,Choice(One(SpineBottomUp(v)),All(Fail)))</code>
	/// <p>
	/// Visitor combinator with one visitor argument that applies this
	/// visitor top-down along a path which reaches from the root to one of 
	/// the leaves.
	/// </summary>
	public class SpineTopDown : Sequence
	{
		public SpineTopDown(IVisitor v) : base(v,null)
		{
			then = new Choice(new One(this),
			new All(new Fail()));
		}
	}
}
