using System;

namespace JJTraveler
{
	/// <summary>
	/// <code>x.accept(Sequence(v1,v2)) = x.accept(v1) ; x.accept(v2)</code>
	/// <p>
	/// Basic visitor combinator with two visitor arguments, that applies
	/// these visitors one after the other (sequential composition).
	/// </summary>
	public class Sequence : IVisitor
	{
		public IVisitor first;
		public IVisitor then;
		public Sequence(IVisitor first, IVisitor then)
		{
			this.first = first;
			this.then  = then;
		}
		public Sequence(IVisitor v1, IVisitor v2, IVisitor v3) 
		{
			first = v1;
			then = new Sequence(v2, v3);
		}
		#region IVisitor Members

		public virtual IVisitable visit(IVisitable any) // throws VisitFailure
		{
			return then.visit(first.visit(any));
		}
		#endregion
		internal virtual void setArgumentAt(int i, IVisitor v) 
		{
			switch (i) 
			{
				case 1: first = v; return;
				case 2: then =v; return;
				default: throw new Exception("Argument out of bounds: "+i);
			}
		}
	}
}