using System;

namespace JJTraveler
{
	/// <summary>
	/// Visitor that checks whether the condition succeeds
	/// for the current node, and subsequently applies
	/// the action to all immediate children. 
	/// Its typical use is to create a conditional path
	/// towards a particular node to which the given
	/// action is applied.
	/// <p>
	/// The child combinator allows one to specify paths
	/// downward a tree.
	/// Child(A, Child(B, Child(C, Action)))
	/// matches a path A.B.C and applies Action to the immediate
	/// children of C.
	/// <p>
	/// See also the Descendant combinator.
	/// 
	/// @author Arie van Deursen; Jul 8, 2003 
	/// @version $Id: Child.java,v 1.1 2004/02/10 20:31:58 arie Exp $  
	/// </summary>
	public class Child : DefinedCombinator
	{
		/**
		 * @param condition Visitor that determines if the action
		 * 		  should be applied.
		 * @param action Visitor to be applied to immediate children.
		 */
		public Child(IVisitor condition, IVisitor childAction)
		{
			setDefinition(new IfThenElse(condition,new All(childAction)));
		}
	}
}
