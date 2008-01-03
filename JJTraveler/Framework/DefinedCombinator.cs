using System;

namespace JJTraveler
{
	/// <summary>
	/// Abstract class for combinators with an explicit definition.
	/// This class helps to set the definition, and to invoke the
	/// definition upon visit.
	///
	/// @author Arie van Deursen, CWI
	/// @version $Id: DefinedCombinator.java,v 1.4 2003/06/30 17:28:37 arie Exp $
	/// </summary>
	public class DefinedCombinator : IVisitor
	{
		
		/** The definition can be provided by setting the
		 *  rhs instance variable.
		 */
		internal IVisitor rhs;

		/** Provide the definition for this combinator.
		 */
		internal virtual void setDefinition(IVisitor definition) 
		{
			rhs = definition;
		}

		/** Return the defining visitor for this combinator.
		 *  following the abstract method design pattern,
		 *  this method can be refined in subclasses if necessary.
		 */
		internal virtual IVisitor getDefinition() 
		{
			return rhs;
		}
		#region IVisitor Members
		/** Visiting defined combinators amounts to visiting
		  *  their definition.
		  */
		public virtual IVisitable visit(IVisitable x) // throws VisitFailure 
		{
			return getDefinition().visit(x);
		}

		#endregion
	}
}
