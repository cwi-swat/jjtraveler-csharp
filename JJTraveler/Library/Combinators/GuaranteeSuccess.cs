using System;

namespace JJTraveler
{
	/// <summary>
	///  The visitor combinator GuaranteeSuccess can be used to indicate
	/// that its argument visitor is guaranteed to succeed. Note that the
	/// visit method of GuaranteeSuccess does not throw VisitFailures,
	/// while the visit method of its argument visitor might. If at
	/// run-time the guarantee is violated, i.e. a VisitFailure occurs,
	/// then then this VisitFailure will be caught and turned into a
	/// RuntimeException.
	/// </summary>
	public class GuaranteeSuccess : IVisitor
	{
		internal IVisitor v;
		/**
		 * Indicate that the argument visitor is guaranteed to succeed.
		 */
		public GuaranteeSuccess(IVisitor v)
		{
			this.v = v;
		}
		#region IVisitor Members
		/* Visit the current visitable with the argument visitor v,
		 * and turn any VisitFailure that might occur into a 
		 * RuntimeException.
		 */
		public virtual IVisitable visit(IVisitable visitable)
		{
			try 
			{
				return v.visit(visitable);
			} 
			catch (VisitFailure f) 
			{
				throw new Exception(f.Message);
			}
		}

		#endregion
	}
}

