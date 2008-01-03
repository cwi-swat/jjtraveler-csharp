using System;

namespace JJTraveler
{
	/// <summary>
	/// Any visitor class should implement the Visitor interface.
	/// </summary>
	public interface IVisitor
	{
	    /**
         * Pay a visit to any visitable object.
         */
		IVisitable visit(IVisitable any); // throws VisitFailure;
	}
}
