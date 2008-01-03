using System;

namespace JJTraveler
{
	/// <summary>
	/// Abstract visitor implementation that has no return value.
	/// </summary>
	public abstract class VoidVisitor : IVisitor
	{
		#region IVisitor Members

		public virtual IVisitable visit(IVisitable any) // throws VisitFailure
		{
			voidVisit(any);
			return any;
		}
		#endregion

		/**
	     * Like <code>visit()</code>, except no visitable needs to be
	     * returned.
	     */
		public abstract void voidVisit(IVisitable any); // throws VisitFailure;
	}
}

