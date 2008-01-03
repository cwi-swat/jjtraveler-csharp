using System;

namespace JJTraveler
{
	/// <summary>
	///  <code>Not(v)</code> succeeds if and only if <code>v</code> fails.
	/// </summary>
	public class Not : IVisitor
	{
		internal IVisitor v;

		public Not(IVisitor v)
		{
			this.v = v;
		}
		#region IVisitor Members

		public virtual IVisitable visit(IVisitable x) // throws VisitFailure
		{
			try 
			{
				v.visit(x);
			}
			catch (VisitFailure) 
			{
				return x;
			}
			throw new VisitFailure();
		}
		#endregion
	}
}

