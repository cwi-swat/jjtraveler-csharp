using System;

namespace JJTraveler
{
	/// <summary>
	/// The Backtrack(StateVisitor) combinator saves the state of its
	/// argument visitor before executing it, and restores this state
	/// afterwards. Note that the argument visitor should clone its state
	/// before modifying it, otherwise state restoration will not work
	/// properly.
	/// </summary>
	public class Backtrack : IVisitor
	{
		internal IStateVisitor v;
		public Backtrack(IStateVisitor v)
		{
			this.v = v;
		}
		#region IVisitor Members

		public virtual IVisitable visit(IVisitable x) // throws VisitFailure			
		{
			Object state = v.getState();
			IVisitable result = v.visit(x);
			v.setState(state);
			return result;		
		}

		#endregion
	}
}