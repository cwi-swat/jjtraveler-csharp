using System;

namespace JJTraveler
{
	/// <summary>
	/// Perform an action in a bottom up fashion
	/// for all nodes along a spine from successfull nodes to the root,
	/// going down only as long as the goDown visitor holds.
	///
	/// @author Arie van Deursen, CWI
	/// </summary>
	public class AllSpinesBottomUp : DefinedCombinator
	{
		internal IVisitor goDown;
		internal IVisitor successNode;
		internal IVisitor action;

		public AllSpinesBottomUp(IVisitor goDown, IVisitor successNode, IVisitor action)
		{
			this.goDown = goDown;
			this.successNode = successNode;
			this.action = action;

			setDefinition(
				new IfThenElse(
					successNode,
					action,
					new IfThenElse(
						goDown,
						new Sequence(new Some(this), action),
			new Fail())));
		}
	}
}
