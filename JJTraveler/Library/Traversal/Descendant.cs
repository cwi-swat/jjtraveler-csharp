using System;

namespace JJTraveler
{
	/// <summary>
	/// Go down the tree until the condition succeeds
	/// on a node -- then apply the descendant action
	/// to the children of that node.
	/// The search does not recurse in nodes below
	/// those that meet the condition.
	/// <p>
	/// This allows expressions such as
	/// Descendant(ProcedureBodyRecognizer, Descendant(SwitchRecognizer, Action))
	/// which would apply an Action to all switch statements that in
	/// turn are contained within ProceduresBodies.
	/// <p>
	/// See also the Child combinator.
	/// 
	/// @author Arie van Deursen; Jun 30, 2003 
	/// @version $Id: Descendant.java,v 1.1 2004/02/10 20:31:58 arie Exp $  
	/// </summary>
	public class Descendant : DefinedCombinator
	{
		public Descendant(IVisitor condition, IVisitor action)
		{
			setDefinition( 
				new TopDownUntil(condition, new All(action)));
		}
	}
}
