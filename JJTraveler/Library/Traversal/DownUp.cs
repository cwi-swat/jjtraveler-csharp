using System;

namespace JJTraveler
{
	/// <summary>
	/// <code>DownUp(down,up) = Sequence(down,Sequence(All(DownUp(down,up)),up))</code>
	/// <p>
	/// <code>DownUp(down,stop,up) = Sequence(down,Sequence(Choice(stop,All(DownUp(down,up))),up))</code>
	/// <p>
	/// Observe that if the stop condition succeeds, the current node
	/// still is visited by both the down and the up visitor.
	/// </summary>
	public class DownUp : Sequence
	{
		public DownUp(IVisitor down, IVisitor up) : base(down, null)
		{
			then = new Sequence(new All(this), up);
		}
		public DownUp(IVisitor down, IVisitor stop, IVisitor up) : base(down, null)
		{
			then = new Sequence(new Choice(stop,new All(this)), up);
		}
	}
}