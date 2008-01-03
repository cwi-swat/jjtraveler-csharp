using System;

namespace JJTraveler
{
	/// <summary>
	/// <code>Try(v) = Choice(v,Identity)</code>
	/// <p>
	/// Visitor combinator with one visitor argument that tries to apply
	/// this visitor to the current visitable. If v fails, Try(v) still
	/// succeeds.
	/// </summary>
	public class Try : Choice
	{
		public Try(IVisitor v) : base(v, new Identity())
		{
		}
	}
}
