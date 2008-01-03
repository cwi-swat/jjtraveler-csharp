using System;

namespace JJTraveler
{
	/// <summary>
	/// <code>x.accept(Identity) = x</code>
	/// <p>
	/// Basic visitor combinator without arguments that does nothing.
	/// <p>
	/// See also <a href="IdentityTest.java">IdentityTest</a>.
	/// </summary>
	public class Identity : IVisitor
	{
		#region IVisitor Members

		public virtual IVisitable visit(IVisitable x)
		{
			return x;
		}

		#endregion
	}
}